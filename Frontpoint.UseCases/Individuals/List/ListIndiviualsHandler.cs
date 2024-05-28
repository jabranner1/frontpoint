using Ardalis.Result;
using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Core.Entities.IndividualAggregate.Specifications;
using MediatR;

namespace Frontpoint.UseCases.Individuals.List;

public class ListIndividualsHandler(IRepository<Individual> repository) : IRequestHandler<ListIndividualsQuery, Result<IEnumerable<IndividualDto>>>
{
    private readonly IRepository<Individual> _repository = repository;

    public async Task<Result<IEnumerable<IndividualDto>>> Handle(ListIndividualsQuery request, CancellationToken cancellationToken)
    {
        var spec = new PaginateIndiviualsSpec(request.Take, request.Skip);
        var result = (await _repository.ListAsync(spec, cancellationToken)) ?? [];
        return Result.Success(result.Select(IndividualDto.FromEntity));
    }
}
