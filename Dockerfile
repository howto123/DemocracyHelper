FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base

WORKDIR /app
EXPOSE $API_PORT


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY "src/WebApi/WebApi.csproj" "WebApi/"
RUN dotnet restore WebApi.WebApi.csproj

COPY . .
WORKDIR /src/WebApi

RUN dotnet build WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT [ "dotnet", "WepApi.dll"]