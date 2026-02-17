sudo runuser -l  postgres -c 'psql -c "
SELECT * FROM cars;
"'