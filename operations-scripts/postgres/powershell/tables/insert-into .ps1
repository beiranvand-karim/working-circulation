sudo runuser -l  postgres -c 'psql -c "
INSERT INTO cars (brand, model, year)
VALUES
  ("Volvo", "p1800", 1968),
  ("BMW", "M1", 1978),
  ("Toyota", "Celica", 1975);
"'