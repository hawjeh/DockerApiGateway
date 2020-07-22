#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . Gateway/
RUN dotnet restore "Gateway/Gateway.csproj"
COPY . .
WORKDIR /src/Gateway
RUN dotnet build "Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.dll"]

# Start
# docker build -t gateway -f Dockerfile .
# docker run -p 88:80 --name gateway -d gateway
# Refresh
# docker stop gateway
# docker rm gateway
# docker run -p 88:80 --name gateway -d gateway
# Kill
# docker stop webapp2
# docker rm webapp2

# setup network
# docker network create webappNetwork
# docker network connect webappNetwork gateway
# docker network connect webappNetwork webapp1
# docker network connect webappNetwork webapp2
# inspect network
# docker network inspect webappNetwork