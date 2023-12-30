FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY Backend/Backend/Backend.csproj Backend/
RUN dotnet restore Backend/Backend.csproj
COPY Backend/Backend Backend/


FROM base AS development

FROM base AS build
RUN dotnet build Backend/Backend.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Backend/Backend.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS production
WORKDIR /release
COPY --from=publish /app/publish /release
EXPOSE 8080
ENTRYPOINT ["dotnet", "Backend.dll"]