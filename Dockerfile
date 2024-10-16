FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 3000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
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
EXPOSE 3000
ENTRYPOINT ["dotnet", "player-dotnet.dll"]