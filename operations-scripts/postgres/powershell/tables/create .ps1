sudo runuser -l  postgres -c 'psql -c "
CREATE TABLE Pokemon (
  Id INT PRIMARY KEY,
  Name VARCHAR(255),
  Type VARCHAR(255)
);
"'