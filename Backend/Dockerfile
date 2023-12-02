FROM mcr.microsoft.com/dotnet/sdk:8.0 AS development
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
WORKDIR /app
COPY . .
ENTRYPOINT dotnet watch run

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Backend/Backend.csproj", "Backend/"]
RUN dotnet restore "Backend/Backend.csproj"
COPY . .
WORKDIR "/src/Backend"
RUN dotnet build "Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS production
WORKDIR /app
EXPOSE 8080
USER app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.dll"]
