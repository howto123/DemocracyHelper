
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /builder
COPY "src/WebApi/WebApi.csproj" "WebApi/"
RUN dotnet restore WebApi/WebApi.csproj

COPY . .
WORKDIR /builder/src/WebApi

RUN dotnet build -c Release -o /app ./WebApi.csproj

FROM build AS publish
RUN dotnet publish WebApi.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
ENTRYPOINT [ "dotnet", "WebApi.dll"]