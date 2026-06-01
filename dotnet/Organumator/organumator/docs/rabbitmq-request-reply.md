# RabbitMQ Request/Reply

## What is RPC?

RPC (Remote Procedure Call) is a pattern that makes a call to a remote service feel like a local function call — you send a request and block waiting for a response, even though it travels over a network.

Message queues are normally fire-and-forget. RPC adds a reply mechanism on top:

- The caller attaches a `ReplyTo` queue and a `CorrelationId` to its message, then waits.
- The consumer processes the command and publishes the result back to `ReplyTo` with the same `CorrelationId`.
- The caller resumes with the response.

```
Caller                    Queue                Consumer
  |---[cmd + ReplyTo]------>|                     |
  |                         |---[dispatch cmd]---->|
  |   (waiting...)          |                     |
  |<---[result]-------------|-----[Reply()]--------|
  |   (resumes)
```

## This project

`QueryAsync` implements the RabbitMQ Request/Reply pattern — a way to do synchronous-feeling calls over an async message bus.

## Steps

**1. Create a temporary reply queue**

A private, auto-deleting queue is created just for this one call. Only this process can see it (`exclusive`), and RabbitMQ deletes it automatically when the channel closes (`autoDelete`).

**2. Create a promise**

A `TaskCompletionSource` acts as a promise — it suspends execution until someone calls `TrySetResult`, at which point `await tcs.Task` resumes.

**3. Listen on the reply queue**

A consumer watches the reply queue. The `CorrelationId` check ignores any stray messages that don't belong to this specific call.

**4. Send the command**

The command is published to the exchange with two metadata fields: `CorrelationId` (to match the reply) and `ReplyTo` (telling the consumer where to send the answer back).

**5. Wait for the reply**

The call suspends here. If the consumer replies within 10 seconds, execution resumes with the deserialized response. If nothing replies in time, a `TimeoutException` is thrown.

**6. Clean up**

The reply channel and its queue are always closed in the `finally` block, regardless of success or failure.

## Flow

```
Controller          Publisher            Exchange         Consumer
    |                   |                    |                |
    |--QueryAsync()---->|                    |                |
    |                   |--publish(cmd)----->|                |
    |                   |   ReplyTo=tmpQ     |--dispatch(cmd)>|
    |   (awaiting tcs)  |                    |                |
    |                   |<-------------------reply(tmpQ)------|
    |                   |  CorrelationId matches              |
    |<--return T--------|                    |                |
```

The consumer calls `Reply(result, props)` which publishes back to `props.ReplyTo` with the same `CorrelationId`, completing the round trip.
