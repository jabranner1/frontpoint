using Ardalis.Result;
using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Frontpoint.UseCases.Individuals.Update;

public class UpdateIndividualHandler(IRepository<Individual> repository, IDateTimeNowProvider dateTime, ILogger<UpdateIndividualHandler> logger) : IRequestHandler<UpdateIndividualCommand, Result<IndividualDto>>
{
    private readonly IRepository<Individual> _repository = repository;
    private readonly IDateTimeNowProvider _dateTime = dateTime;
    private readonly ILogger<UpdateIndividualHandler> _logger = logger;

    public async Task<Result<IndividualDto>> Handle(UpdateIndividualCommand request, CancellationToken cancellationToken = default)
    {
        var individual = await _repository.GetByIdAsync(request.IndividualId, cancellationToken);
        if (individual == null)
        {
            _logger.LogWarning("GetByIdAsync({Id}) not found", request.IndividualId);
            return Result.NotFound();
        }

        _logger.LogInformation("Preparing to update individual: {@Individual} client: {ClientId}", individual, request.ClientId);

        individual.Prefix = request.Individual.Prefix;
        individual.FirstName = request.Individual.FirstName;
        individual.MiddleName = request.Individual.MiddleName;
        individual.LastName = request.Individual.LastName;
        individual.DateOfBirth = request.Individual.DateOfBirth;
        individual.TelephoneNumber = request.Individual.TelephoneNumber;
        individual.AddressLine1 = request.Individual.AddressLine1;
        individual.AddressLine2 = request.Individual.AddressLine2;
        individual.City = request.Individual.City;
        individual.State = request.Individual.State;
        individual.Zip = request.Individual.Zip;
        individual.Country = request.Individual.Country;

        individual.LastUpdatedBy = request.ClientId;
        individual.LastUpdatedAt = _dateTime.UtcNow();

        try
        {
            await _repository.UpdateAsync(individual, cancellationToken);
            _logger.LogInformation("Updated individual: {@Individual} client: {ClientId}", individual, request.ClientId);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to update individual: {@Individual} client: {ClientId} error: {Error}", individual, request.ClientId, ex.ToString());
            throw;
        }

        return Result.Success(IndividualDto.FromEntity(individual));
    }
}