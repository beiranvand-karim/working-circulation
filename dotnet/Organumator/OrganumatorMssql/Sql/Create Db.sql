
IF NOT EXISTS (SELECT name
FROM sys.databases
WHERE name = N'finshark')
    CREATE DATABASE finshark;