using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Infrastructure.Data;
using Frontpoint.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Frontpoint.IntegrationTests.Data;

public abstract class RepositoryBaseTestFixture
{
    protected FrontpointDbContext _dbContext;

    protected RepositoryBaseTestFixture()
    {
        var options = CreateNewContextOptions();
        _dbContext = new FrontpointDbContext(options);
    }

    protected static DbContextOptions<FrontpointDbContext> CreateNewContextOptions()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<FrontpointDbContext>();
        builder.UseInMemoryDatabase("frontpoint")
               .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }

    protected IRepository<Individual> GetRepository()
    {
        return new IndividualRepository(_dbContext);
    }
}
