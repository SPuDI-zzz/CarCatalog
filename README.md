# CarCatalog

##Docker

**Start the PostgreSQL in the Docker**

Download the PostgreSQL image in Docker.

```sh
docker pull postgres
```

Create container.

```sh
docker run --name postgres --restart=always -p 25432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Passw0rd -e POSTGRES_DB=postgres -v postgresvolume:/var/lib/postgresql/data -d postgres
```

**Start the MSSQL in the Docker**

Download the MSSQL image in Docker.

```sh
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

Create container.

```sh
docker run -e "ACCEPT_EULA=Y" --name=SQL --restart=always -e "MSSQL_SA_PASSWORD=Passw0rd" -p 1433:1433 -v sqlvolume:/var/opt/mssql -v sqlvolume:/var/opt/dtemp -d mcr.microsoft.com/mssql/server:2022-latest
```

##Start the project

- Open the project.
- Set as Startup Project CarCatalog.Api
- Start