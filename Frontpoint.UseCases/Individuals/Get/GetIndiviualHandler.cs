using Ardalis.Result;
using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Frontpoint.UseCases.Individuals.Get;

public class GetIndividualHandler(IRepository<Individual> repository, ILogger<GetIndividualHandler> logger) : IRequestHandler<GetIndividualQuery, Result<IndividualDto>>
{
    private readonly IRepository<Individual> _repository = repository;
    private readonly ILogger<GetIndividualHandler> _logger = logger;

    public async Task<Result<IndividualDto>> Handle(GetIndividualQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.IndividualId, cancellationToken);
        if (result == null)
        {
            _logger.LogWarning("GetByIdAsync({Id}) not found", request.IndividualId);
            return Result.NotFound();
        }

        return Result.Success(IndividualDto.FromEntity(result));
    }
}
