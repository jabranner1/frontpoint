using Ardalis.Result;
using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Frontpoint.UseCases.Individuals.Create;

public class CreateIndividualHandler(IRepository<Individual> repository, IDateTimeNowProvider dateTime, ILogger<CreateIndividualHandler> logger) : IRequestHandler<CreateIndividualCommand, Result<IndividualDto>>
{
    private readonly IRepository<Individual> _repository = repository;
    private readonly IDateTimeNowProvider _dateTime = dateTime;
    private readonly ILogger<CreateIndividualHandler> _logger = logger;

    public async Task<Result<IndividualDto>> Handle(CreateIndividualCommand request, CancellationToken cancellationToken = default)
    {
        var individual = IndividualDto.ToEntity(request.Individual);
        individual.CreatedAt = _dateTime.UtcNow();
        individual.CreatedBy = request.ClientId;

        _logger.LogInformation("Preparing to create individual: {@Individual} client: {ClientId}", individual, request.ClientId);

        Individual? newIndividual;
        try
        {
            newIndividual = await _repository.AddAsync(individual, cancellationToken);
            _logger.LogInformation("Created individual: {@Individual} client: {ClientId}", individual, request.ClientId);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to create individual: {@Individual} client: {ClientId} error: {Error}", individual, request.ClientId, ex.ToString());
            throw;
        }

        return Result.Success(IndividualDto.FromEntity(newIndividual));
    }
}
