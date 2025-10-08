using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using Repository;

using Scalar.AspNetCore;

using WebApi.Infrastructure.Api;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.AddRedisClient(connectionName: "cache");
builder.AddNpgsqlDbContext<AppDbContext>(connectionName: "database", opt => opt.ConnectionString = connectionString);
builder.Services
    .AddOpenApi()
    .AddPersistence();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();

// Documentation pour SWAGGER
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Activation du swagger
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();
app.MapUserEndpoints();
app.MapHealthChecks("/health");

app.Run();

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public partial class Program;