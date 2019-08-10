# Obtendo imagem mais recente do SQL Server para Linux
FROM mcr.microsoft.com/mssql/server:2017-latest AS base

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=desenvol2019!

COPY . .

RUN chmod +x ./setup.sh

#RUN /opt/mssql/bin/sqlservr
#RUN echo "Aguardando SQL Server iniciar...."
#RUN sleep 90
#RUN echo "Logando SQL Server"
#RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -d master -i create.sql

CMD /bin/bash & /opt/mssql/bin/sqlservr & (echo "Aguardando SQL Server iniciar...." && sleep 15 &&  /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P desenvol2019! -d master -i create.sql && /bin/bash)

#WORKDIR /app

# Copia o arquivo que todos os scripts de cria��o e configura��o do banco e de tabelas para dentro do container
#COPY . .

# Da permiss�o pro user executar os scripts que foram copiados
#RUN chmod +x ./setup.sh

#RUN /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P desenvol2019! -d master -i create.sql

#CMD /bin/bash & ./entrypoint.sh
