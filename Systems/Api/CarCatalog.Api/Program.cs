using CarCatalog.Api;
using CarCatalog.Api.Configuration;
using CarCatalog.Context;
using CarCatalog.Services.Settings;
using CarCatalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var identitySettings = Settings.Load<IdentitySettings>("Identity");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger();

// Configure services

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppDbContext(builder.Configuration);

services.AddAppAuth(identitySettings);

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(identitySettings, swaggerSettings);

services.AddAppAutoMappers();

services.AddAppControllerAndViews();

services.RegisterAppServices();

var app = builder.Build();

app.UseAppCors();

app.UseStaticFiles();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.UseAppAuth();

app.UseAppControllerAndViews();

app.UseAppMiddlewares();

DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services, true, true);

app.Run();
