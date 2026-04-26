FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu

COPY ./wait-and-run.sh /wait-and-run.sh
COPY ./CreateDatabaseAndSeedScripts.sql /CreateDatabaseAndSeedScripts.sql

RUN chmod +x /wait-and-run.sh

CMD ["/wait-and-run.sh"]