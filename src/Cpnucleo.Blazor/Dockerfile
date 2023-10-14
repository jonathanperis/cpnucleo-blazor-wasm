FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

LABEL maintainer "Jonathan Peris"

USER app
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

FROM nginx:alpine AS final

WORKDIR /usr/share/nginx/html
COPY --from=build /src/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf