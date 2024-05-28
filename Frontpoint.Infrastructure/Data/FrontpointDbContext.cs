using Frontpoint.Core.Entities.IndividualAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Frontpoint.Infrastructure.Data;

public class FrontpointDbContext(DbContextOptions<FrontpointDbContext> options) : DbContext(options)
{
    public DbSet<Individual> Individuals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
