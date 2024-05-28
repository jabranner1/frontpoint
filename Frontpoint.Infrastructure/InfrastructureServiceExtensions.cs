using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Infrastructure.Data;
using Frontpoint.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Frontpoint.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
      this IServiceCollection services,
      string? connectionString)
    {
        Guard.Against.NullOrEmpty(connectionString);

        services.AddDbContext<FrontpointDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped(typeof(IRepository<Individual>), typeof(IndividualRepository));

        return services;
    }
}
