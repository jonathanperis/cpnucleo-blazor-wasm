FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

LABEL maintainer "Jonathan Peris"

USER app
WORKDIR /app

COPY . .

RUN ls -s

WORKDIR /app/wwwroot

RUN ls -s

WORKDIR /app/wwwroot/wwwroot

RUN ls -s

FROM nginx:alpine AS final

WORKDIR /usr/share/nginx/html
COPY --from=base /app/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf