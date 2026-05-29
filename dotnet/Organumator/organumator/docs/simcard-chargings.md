# JSON File Storage

Data is stored as JSON files organised by year and month.

## Storage Location

Files are stored under the user's Documents folder:

```
~/Documents/organizing/simcard-chargings/
```

The base path is resolved at runtime via `Environment.SpecialFolder.MyDocuments` and can be overridden with the `SimcardChargings:DataPath` setting in `appsettings.json`.

## Directory Structure

```
~/Documents/organizing/simcard-chargings/
├── development/
│   └── {yyyy}/
│       └── {MM}/
│           └── simcard-charging-{yyyy-MM-dd}.json
└── production/
    └── {yyyy}/
        └── {MM}/
            └── simcard-charging-{yyyy-MM-dd}.json
```

## File Format

Each file holds a JSON array of records for that day.

```json
[
  {
    "id": 1,
    "chargedAt": "2026-05-30T14:22:00"
  }
]
```

## API

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/simcardchargings` | Return all records, newest first |
| GET | `/api/simcardchargings/{id}` | Return a single record by id |
| POST | `/api/simcardchargings` | Record a new charging at the current time |
| DELETE | `/api/simcardchargings/{id}` | Delete a record by id |

## Lifecycle

- A file is created when the first record for that day is saved.
- When the last record in a file is deleted, the file is removed.
- When a month or year directory becomes empty it is removed as well.
