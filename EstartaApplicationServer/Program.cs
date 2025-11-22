using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using EstartaApplicationServer.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppCtx>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

IOC.Application.ApplicationDI.AddApplicationServices(builder.Services);
IOC.Infrastructure.InfrastructureDI.AddInfrastructureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger services
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Estarta Application API",
        Version = "v1",
        Description = "API documentation for Estarta Application Server"
    });
    // Optional: Include XML comments if available
    // var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Add this line before other middleware registrations (e.g., before UseRouting, UseEndpoints, etc.)
app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppCtx>();
    db.Database.Migrate();
}

// Seed database on startup (optional, for dev/demo)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppCtx>();
    await db.SeedDatabaseAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Estarta Application API v1");
    options.RoutePrefix = "swagger"; // Swagger UI at /swagger
});

app.UseAuthorization();

app.MapControllers();

app.Run();
