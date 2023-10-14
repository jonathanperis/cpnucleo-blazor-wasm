FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

LABEL maintainer "Jonathan Peris"

USER app
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

WORKDIR /src/wwwroot

RUN ls -s

FROM base AS final

WORKDIR /app
COPY --from=build /src/wwwroot .
# ENTRYPOINT ["dotnet", "Cpnucleo.Blazor.dll"]