#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/CarCatalog.Api/CarCatalog.Api.csproj", "Systems/Api/CarCatalog.Api/"]
COPY ["Data/CarCatalog.Context/CarCatalog.Context.csproj", "Data/CarCatalog.Context/"]
COPY ["Shared/CarCatalog.Settings/CarCatalog.Settings.csproj", "Shared/CarCatalog.Settings/"]
COPY ["Data/CarCatalog.Context.Entities/CarCatalog.Context.Entities.csproj", "Data/CarCatalog.Context.Entities/"]
COPY ["Data/Migrations/CarCatalog.Context.MigrationsPostgreSQL/CarCatalog.Context.MigrationsPostgreSQL.csproj", "Data/Migrations/CarCatalog.Context.MigrationsPostgreSQL/"]
COPY ["Services/CarCatalog.Services.CarBodyType/CarCatalog.Services.CarBodyType.csproj", "Services/CarCatalog.Services.CarBodyType/"]
COPY ["Services/CarCatalog.Services.CarConfiguration/CarCatalog.Services.CarConfiguration.csproj", "Services/CarCatalog.Services.CarConfiguration/"]
COPY ["Services/CarCatalog.Services.CarDriveType/CarCatalog.Services.CarDriveType.csproj", "Services/CarCatalog.Services.CarDriveType/"]
COPY ["Services/CarCatalog.Services.CarEngineType/CarCatalog.Services.CarEngineType.csproj", "Services/CarCatalog.Services.CarEngineType/"]
COPY ["Services/CarCatalog.Services.CarForSale/CarCatalog.Services.CarForSale.csproj", "Services/CarCatalog.Services.CarForSale/"]
COPY ["Services/CarCatalog.Services.CarGeneration/CarCatalog.Services.CarGeneration.csproj", "Services/CarCatalog.Services.CarGeneration/"]
COPY ["Services/CarCatalog.Services.CarMark/CarCatalog.Services.CarMark.csproj", "Services/CarCatalog.Services.CarMark/"]
COPY ["Services/CarCatalog.Services.CarModel/CarCatalog.Services.CarModel.csproj", "Services/CarCatalog.Services.CarModel/"]
COPY ["Services/CarCatalog.Services.CarTransmission/CarCatalog.Services.CarTransmission.csproj", "Services/CarCatalog.Services.CarTransmission/"]
COPY ["Services/CarCatalog.Services.Comment/CarCatalog.Services.Comment.csproj", "Services/CarCatalog.Services.Comment/"]
COPY ["Services/CarCatalog.Services.Country/CarCatalog.Services.Country.csproj", "Services/CarCatalog.Services.Country/"]
COPY ["Services/CarCatalog.Services.Settings/CarCatalog.Services.Settings.csproj", "Services/CarCatalog.Services.Settings/"]
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