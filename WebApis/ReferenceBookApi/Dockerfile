FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "WebApis/ReferenceBookApi/ReferenceBookApi.csproj"
COPY . .
WORKDIR "/src/WebApis/ReferenceBookApi"
RUN dotnet build "./ReferenceBookApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./ReferenceBookApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReferenceBookApi.dll"]
