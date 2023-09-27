FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

LABEL maintainer "Jonathan Peris"

USER app
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["src/Cpnucleo.Blazor/Cpnucleo.Blazor.csproj", "src/Cpnucleo.Blazor/"]

RUN dotnet workload install wasm-tools

RUN dotnet restore "src/Cpnucleo.Blazor/Cpnucleo.Blazor.csproj"

COPY . .

WORKDIR "/src/src/Cpnucleo.Blazor"

RUN dotnet build "Cpnucleo.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cpnucleo.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cpnucleo.Blazor.dll"]