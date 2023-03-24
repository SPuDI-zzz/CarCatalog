using CarCatalog.Api;
using CarCatalog.Api.Configuration;
using CarCatalog.Context;
using CarCatalog.Services.Settings;
using CarCatalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger();

// Configure services

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppDbContext();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings);

services.AddAppAutoMappers();

services.AddAppControllerAndViews();

services.RegisterAppServices();

var app = builder.Build();

app.UseStaticFiles();

app.UseAppHealthChecks();

app.UseAppSwagger();

DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services, true, true);

// Configure the HTTP request pipeline.

app.UseAppControllerAndViews();

app.Run();
