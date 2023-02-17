#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/CarCatalog.Api/CarCatalog.Api.csproj", "Systems/Api/CarCatalog.Api/"]
COPY ["Services/CarCatalog.Services.Settings/CarCatalog.Services.Settings.csproj", "Services/CarCatalog.Services.Settings/"]
COPY ["Shared/CarCatalog.Settings/CarCatalog.Settings.csproj", "Shared/CarCatalog.Settings/"]
COPY ["Shared/CarCatalog.Common/CarCatalog.Common.csproj", "Shared/CarCatalog.Common/"]
COPY ["Systems/Api/CarCatalog.Api.Settings/CarCatalog.Api.Settings.csproj", "Systems/Api/CarCatalog.Api.Settings/"]
RUN dotnet restore "Systems/Api/CarCatalog.Api/CarCatalog.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/CarCatalog.Api"
RUN dotnet build "CarCatalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarCatalog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarCatalog.Api.dll"]