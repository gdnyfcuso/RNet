library("RMySQL");
# Create a connection Object to MySQL database.
# We will connect to the sampel database named "testdb" that comes with MySql installation.
mysqlconnection = dbConnect(MySQL(), user = 'dben', password = 'dben', dbname = 'ei',
   host = 'localhost')

# List the tables available in this database.
dbListTables(mysqlconnection)

result = dbSendQuery(mysqlconnection, "select * from zzzdbmigrationversion")

# Store the result in a R data frame object. n = 5 is used to fetch first 5 rows.
data.frame = fetch(result, n = 5)
print(data.frame)