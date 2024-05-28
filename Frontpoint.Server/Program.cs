using Ardalis.SharedKernel;
using Frontpoint.Core;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Infrastructure;
using Frontpoint.Infrastructure.Data;
using Frontpoint.UseCases.Individuals;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
builder.Services.AddSerilog();

builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("SqliteConnection"));

ConfigureMediatR();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

SeedDatabase(app);

app.Run();

void ConfigureMediatR()
{
    var mediatRAssemblies = new[]
    {
    Assembly.GetAssembly(typeof(Individual)), // Core
    Assembly.GetAssembly(typeof(IndividualDto)), // UseCases
    Assembly.GetAssembly(typeof(InfrastructureServiceExtensions)) // Infrastructure
  };

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}

static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<FrontpointDbContext>();
        context.Database.Migrate();
        SeedData.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
}