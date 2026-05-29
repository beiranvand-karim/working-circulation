# JSON File Storage

Data is stored as JSON files organised by environment, year, month, and week.

## Storage Location

Files are stored under the user's Documents folder:

```
~/Documents/organizing/time-trackings/
```

The base path is resolved at runtime via `Environment.SpecialFolder.MyDocuments` and can be overridden with the `TimeTrackings:DataPath` setting in `appsettings.json`.

## Directory Structure

```
~/Documents/organizing/time-trackings/
├── development/
│   └── {yyyy}/
│       └── {MM}/
│           └── week-{n}/
│               └── cleanup-{yyyy-MM-dd}.json
└── production/
    └── {yyyy}/
        └── {MM}/
            └── week-{n}/
                └── cleanup-{yyyy-MM-dd}.json
```

## Week Numbering

Weeks are calculated from the day of the month:

| Week    | Days    |
|---------|---------|
| week-1  | 1 – 7   |
| week-2  | 8 – 14  |
| week-3  | 15 – 21 |
| week-4  | 22 – 28 |
| week-5  | 29 – 31 |

## File Format

Each file holds a JSON array of records for that day.

```json
[
  {
    "id": 1,
    "startedAt": "2026-05-27T09:00:00",
    "finishedAt": "2026-05-27T09:45:00"
  }
]
```

## Lifecycle

- A file is created when the first record for that day is saved.
- When the last record in a file is deleted, the file is removed.
- When a week, month, or year directory becomes empty it is removed as well.
