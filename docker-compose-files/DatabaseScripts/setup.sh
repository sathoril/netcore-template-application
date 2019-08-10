echo "Aguardando SQL Server iniciar...." & \
sleep 90 & \
echo "Logando SQL Server" & \
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -d master -i create.sql