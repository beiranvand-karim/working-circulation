sudo runuser -l  postgres -c 'psql -c "
CREATE TABLE cars (
  brand VARCHAR(255),
  model VARCHAR(255),
  year INT
);
"'