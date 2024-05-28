using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Infrastructure.Data;

namespace Frontpoint.Infrastructure.Repositories;

public class IndividualRepository(FrontpointDbContext dbContext) : RepositoryBase<Individual>(dbContext), IRepository<Individual>
{
}
