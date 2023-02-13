using CarCatalog.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddAppLogger();

// Configure services

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppHealthChecks();

services.AddAppVersioning();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAppHealthChecks();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
