#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Identity/CarCatalog.Identity/CarCatalog.Identity.csproj", "Systems/Identity/CarCatalog.Identity/"]
COPY ["Data/CarCatalog.Context.Entities/CarCatalog.Context.Entities.csproj", "Data/CarCatalog.Context.Entities/"]
COPY ["Data/CarCatalog.Context/CarCatalog.Context.csproj", "Data/CarCatalog.Context/"]
COPY ["Shared/CarCatalog.Settings/CarCatalog.Settings.csproj", "Shared/CarCatalog.Settings/"]
COPY ["Shared/CarCatalog.Common/CarCatalog.Common.csproj", "Shared/CarCatalog.Common/"]
RUN dotnet restore "Systems/Identity/CarCatalog.Identity/CarCatalog.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/CarCatalog.Identity"
RUN dotnet build "CarCatalog.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarCatalog.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarCatalog.Identity.dll"]