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

services.AddAppSwagger();

services.AddAppControllerAndViews();

var app = builder.Build();

app.UseAppHealthChecks();

app.UseAppSwagger();

// Configure the HTTP request pipeline.

app.UseAppControllerAndViews();

app.Run();
