﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["player-dotnet.csproj", "."]
RUN dotnet restore "player-dotnet.csproj"
COPY . .
RUN dotnet build "player-dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "player-dotnet.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "player-dotnet.dll"]