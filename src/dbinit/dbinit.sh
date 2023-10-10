#!/bin/bash
echo 'Waiting server startup (30s)'

SA_PASSWORD='*ABcZ123#'
DB_NAME='GameDatabase'

sleep 30s

echo 'Checking Users database'
data=$(/opt/mssql-tools/bin/sqlcmd -S sqlserver -U SA -P $SA_PASSWORD -Q "SELECT COUNT(*)  FROM master.dbo.sysdatabases WHERE name = N'$DB_NAME'" | tr -dc '0-9'| cut -c1 )

if [ ${data} -eq "0" ]; then
	echo "Creating $DB_NAME database"
	/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P $SA_PASSWORD -Q "DROP DATABASE IF EXISTS $DB_NAME"
	/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P $SA_PASSWORD -d master -i /tmp/dbinit/dbinit.sql
	/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P $SA_PASSWORD -d master -i /tmp/dbinit/seed.sql''
else
	echo "$DB_NAME database already exists"
fi


#echo 'Running database init script dbinit/dbinit.sql'
#/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P *ABcZ123# -d master -i /tmp/dbinit/dbinit.sql