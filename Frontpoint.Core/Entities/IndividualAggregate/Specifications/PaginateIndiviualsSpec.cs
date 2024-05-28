using Ardalis.Specification;

namespace Frontpoint.Core.Entities.IndividualAggregate.Specifications;

public class PaginateIndiviualsSpec : Specification<Individual>
{
    public PaginateIndiviualsSpec(int? take = null, int? skip = null)
    {
        Query
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .Skip(skip ?? 0)
            .Take(take ?? 10);
    }
}
