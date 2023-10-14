FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

LABEL maintainer "Jonathan Peris"

USER app
WORKDIR /app

COPY . .

FROM nginx:alpine AS final

WORKDIR /user/share/nginx/html
COPY --from=base /app/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf