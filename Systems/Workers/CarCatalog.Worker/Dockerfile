#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Workers/CarCatalog.Worker/CarCatalog.Worker.csproj", "Systems/Workers/CarCatalog.Worker/"]
COPY ["Data/CarCatalog.Context/CarCatalog.Context.csproj", "Data/CarCatalog.Context/"]
COPY ["Shared/CarCatalog.Common/CarCatalog.Common.csproj", "Shared/CarCatalog.Common/"]
COPY ["Shared/CarCatalog.Settings/CarCatalog.Settings.csproj", "Shared/CarCatalog.Settings/"]
COPY ["Data/CarCatalog.Context.Entities/CarCatalog.Context.Entities.csproj", "Data/CarCatalog.Context.Entities/"]
COPY ["Services/CarCatalog.Services.EmailSender/CarCatalog.Services.EmailSender.csproj", "Services/CarCatalog.Services.EmailSender/"]
COPY ["Services/CarCatalog.Services.RabbitMq/CarCatalog.Services.RabbitMq.csproj", "Services/CarCatalog.Services.RabbitMq/"]
COPY ["Shared/CarCatalog.Consts/CarCatalog.Consts.csproj", "Shared/CarCatalog.Consts/"]
RUN dotnet restore "Systems/Workers/CarCatalog.Worker/CarCatalog.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Workers/CarCatalog.Worker"
RUN dotnet build "CarCatalog.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarCatalog.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarCatalog.Worker.dll"]