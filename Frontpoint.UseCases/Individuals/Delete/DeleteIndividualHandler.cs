using Ardalis.Result;
using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Frontpoint.UseCases.Individuals.Delete;

public class DeleteIndividualHandler(IRepository<Individual> repository, ILogger<DeleteIndividualHandler> logger) : IRequestHandler<DeleteIndividualCommand, Result>
{
    private readonly IRepository<Individual> _repository = repository;
    private readonly ILogger<DeleteIndividualHandler> _logger = logger;

    public async Task<Result> Handle(DeleteIndividualCommand request, CancellationToken cancellationToken = default)
    {
        var individual = await _repository.GetByIdAsync(request.IndividualId, cancellationToken);
        if (individual == null)
        {
            _logger.LogWarning("GetByIdAsync({Id}) not found", request.IndividualId);
            return Result.NotFound();
        }

        _logger.LogInformation("Preparing to delete individual: {@Individual} client: {ClientId}", individual, request.ClientId);

        try
        {
            await _repository.DeleteAsync(individual, cancellationToken);
            _logger.LogInformation("Deleted individual: {@Individual} client: {ClientId}", individual, request.ClientId);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to delete individual: {@Individual} client: {ClientId} error: {Error}", individual, request.ClientId, ex.ToString());
            throw;
        }

        return Result.Success();
    }
}