# JSON File Storage

Data is stored as JSON files organised by year and month, based on the wearing start date.

## Storage Location

Files are stored under the user's Documents folder:

```
~/Documents/organizing/trackings/clothes-wearings/
```

The base path is resolved at runtime via `Environment.SpecialFolder.MyDocuments` and can be overridden with the `ClothesWearings:DataPath` setting in `appsettings.json`.

## Directory Structure

```
~/Documents/organizing/trackings/clothes-wearings/
├── development/
│   └── {yyyy}/
│       └── {MM}/
│           └── clothes-wearing-{yyyy-MM-dd}.json
└── production/
    └── {yyyy}/
        └── {MM}/
            └── clothes-wearing-{yyyy-MM-dd}.json
```

Files are bucketed by the date of `WearingStart`. If `WearingStart` changes during an update the record is moved to the new date's file automatically.

## File Format

Each file holds a JSON array of records for that day.

```json
[
  {
    "id": 1,
    "differentiator": "blue jeans",
    "wearingStart": "2026-05-30T08:00:00",
    "wearingFinish": null
  }
]
```

`wearingFinish` is `null` when the item is still being worn. It is set to the current timestamp when the user presses the Finish button.

## Caching

GetAll responses are cached in Redis under the key `ClothesWearings:all` for 5 minutes. The cache is invalidated on every create, update, or delete.

## Messaging

Commands are routed through RabbitMQ. The queue name is environment-specific:

| Environment | Queue |
|-------------|-------|
| Development | `organumator-dev.clothes-wearing.commands` |
| Production  | `organumator-prod.clothes-wearing.commands` |

Configured via `RabbitMQ:ClothesWearingCommandQueueName` in `appsettings.json`.

| Action   | Triggered by   | Reply |
|----------|----------------|-------|
| GetAll   | GET /          | yes   |
| GetById  | GET /{id}      | yes   |
| Create   | POST /         | yes   |
| Update   | PUT /{id}      | no    |
| Delete   | DELETE /{id}   | no    |

Mutation actions (Create, Update, Delete) also publish an event message to the main events queue.

### Consumer internals

`ClothesWearingCommandConsumer` is a `BackgroundService`. `ExecuteAsync` is the entry point called by .NET when the app starts. It does one-time setup then returns immediately — the consumer runs on its own thread from that point on.

**1. Connect and declare**

Creates a RabbitMQ connection and channel, then declares the exchange, queue, and binding. This is idempotent — if they already exist with the same settings RabbitMQ does nothing.

**2. Register a message handler**

Attaches a callback to `consumer.Received` that fires for every incoming message:

- Deserializes the body as a `ClothesWearingCommand`. If deserialization fails the message is Nack'd without requeue.
- Creates a DI scope for each message. This is required because `IClothesWearingRepository` is a scoped service — it cannot be injected directly into a singleton `BackgroundService`.
- Dispatches to the right handler via a switch on `command.Action`. Unknown actions are silently ignored.
- On success: `BasicAck`. On exception: logs the error and `BasicNack` with `requeue: true`.

**3. Start consuming**

`BasicConsume` with `autoAck: false` — messages are only acknowledged after the handler succeeds, preventing data loss if the app crashes mid-processing.

`BasicConsume` does not start a separate process. The `EventingBasicConsumer` delivers messages by invoking the `Received` callback on a thread managed by the RabbitMQ client library — but that thread lives inside the same app process:

```
Your app process
├── ASP.NET Core request threads  (handle HTTP)
├── BackgroundService host thread (calls ExecuteAsync once, then moves on)
└── RabbitMQ client thread        (fires Received callback per message)
```

Because the callback is `async`, after the first `await` it may resume on a different .NET thread pool thread — still inside the same process.

**4. Return immediately**

`ExecuteAsync` returns `Task.CompletedTask` right away. The RabbitMQ consumer runs on its own thread from here on. The `stoppingToken` parameter is never used — the consumer keeps running until `Dispose()` closes the channel and connection.

**DeliveryTag**

Every message delivered to a consumer gets a `DeliveryTag` — a channel-scoped integer that increments with each delivery. It is the receipt RabbitMQ gives you for that specific message. You pass it back in `BasicAck` or `BasicNack` to tell RabbitMQ exactly which message you are settling. Without it RabbitMQ would not know which of the potentially many in-flight messages you mean. The `multiple` flag is always `false` here. `false` settles only the one message identified by the `DeliveryTag`. `true` would bulk-settle every unacknowledged message up to and including that tag on the channel — useful for batching, but dangerous here because messages are processed one at a time and each needs individual success/failure tracking.

**Reply helper**

Query actions (GetAll, GetById) and Create need to return data to the caller. The private `Reply<T>` method handles this:

- Returns immediately if `ReplyTo` is null (fire-and-forget callers).
- Creates reply properties with the same `CorrelationId` as the request so the caller can match the response.
- Publishes the JSON-serialized result to the default exchange, routing directly to `ReplyTo`.

See [rabbitmq-request-reply.md](rabbitmq-request-reply.md) for the full round-trip flow.

## API

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/clotheswearings` | Return all records, newest first |
| GET | `/api/clotheswearings/{id}` | Return a single record by id |
| POST | `/api/clotheswearings` | Create a new wearing record (`wearingFinish` starts as `null`) |
| PUT | `/api/clotheswearings/{id}` | Update a record (used internally to set `wearingFinish`) |
| DELETE | `/api/clotheswearings/{id}` | Delete a record by id |

## Lifecycle

- A file is created when the first record for that day is saved.
- When the last record in a file is deleted, the file is removed.
- When a month or year directory becomes empty it is removed as well.
