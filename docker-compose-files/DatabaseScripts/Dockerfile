# Obtendo imagem mais recente do SQL Server para Linux
FROM mcr.microsoft.com/mssql/server:2017-latest AS base

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=desenvol2019!

COPY . .

RUN chmod +x ./setup.sh

CMD /bin/bash & /opt/mssql/bin/sqlservr & (echo "Aguardando SQL Server iniciar...." && sleep 90 &&  /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P desenvol2019! -d master -i create.sql && /bin/bash)