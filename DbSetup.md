### Set up a Database

#### Set up Db Container

Create a Volume:

docker volume create DemocracyHelperDevDatabase


Dockernetwork (docker network create S_to_Db):

docker run --rm --name democracyhelper_db -e POSTGRES_USER=democracyhelper -e POSTGRES_PASSWORD=mysecretpassword -e PGDATA=/var/lib/postgresql/data/pgdata -v DemocracyHelperDevDatabase:/var/lib/postgresql/data/pgdata -v DemocracyHelperDevDatabase:/var/lib/pgsql/data --network S_to_Db -d postgres:16


Port exposed to host:

docker run --rm --name democracyhelper_db -e POSTGRES_USER=democracyhelper -e POSTGRES_PASSWORD=mysecretpassword -e PGDATA=/var/lib/postgresql/data/pgdata -v DemocracyHelperDevDatabase:/var/lib/postgresql/data/pgdata -p 5432:5432 -d postgres:16

<br/>

#### Use Dotnet EF to create Database

Set up DbContex

Set DB_STRING env variable, here for Windows:

$env:DB_STRING="Host=localhost;Username=democracyhelper;Password=mysecretpassword;Database=democracyhelper"
${DB_STRING} -> check

<br/>

Some EF commands

dotnet add src/WebApi/WebApi.csproj package Npgsql.EntityFrameworkCore.PostgreSQL --version 7

dotnet add src/WebApi/WebApi.csproj package Microsoft.EntityFrameworkCore.Design -v 7

dotnet ef migrations --project src/WebApi/WebApi.csproj add InitialCreate

dotnet ef --project src/WebApi/WebApi.csproj database update