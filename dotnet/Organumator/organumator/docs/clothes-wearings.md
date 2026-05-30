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
