FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "WebApis/LearningApi/LearningApi.csproj"
COPY . .
WORKDIR "/src/WebApis/LearningApi"
RUN dotnet build "./LearningApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./LearningApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningApi.dll"]
