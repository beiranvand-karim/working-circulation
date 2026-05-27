# JSON File Storage

Data is stored as JSON files organised by environment, year, month, and week.

## Directory Structure

```
Data/json/
├── development/
│   └── {yyyy}/
│       └── {MM}/
│           └── week-{n}/
│               └── {yyyy-MM-dd}.json
└── production/
    └── {yyyy}/
        └── {MM}/
            └── week-{n}/
                └── {yyyy-MM-dd}.json
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
