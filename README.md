# CarCatalog

## Docker

**Start the PostgreSQL in the Docker**

Download the PostgreSQL image in Docker. Write in Developer PowerShell

```sh
docker pull postgres
```

Create container.

```sh
docker run --name postgres --restart=always -p 25432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Passw0rd -e POSTGRES_DB=postgres -v postgresvolume:/var/lib/postgresql/data -d postgres
```

## Start the project

- Developer PowerShell in Visual Studio
- Write docker-compose build
- Write docker-compose up
- Open in browser http://localhost:10000/
