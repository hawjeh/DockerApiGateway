#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . WebApp1/
RUN dotnet restore "WebApp1/WebApp1.csproj"
COPY . .
WORKDIR /src/WebApp1
RUN dotnet build "WebApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp1.dll"]

# Start
# docker build -t webapp1 -f Dockerfile .
# docker run -p 81:80 --name webapp1 -d webapp1
# Refresh
# docker stop webapp1
# docker rm webapp1
# docker run -p 81:80 --name webapp1 -d webapp1
# Kill
# docker stop webapp2
# docker rm webapp2