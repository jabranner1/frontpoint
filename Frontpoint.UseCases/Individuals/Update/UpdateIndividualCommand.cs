using Ardalis.Result;
using MediatR;

namespace Frontpoint.UseCases.Individuals.Update;

/// <summary>
/// Update an individual
/// </summary>
/// <param name="IndividualId"></param>
/// <param name="Individual"></param>
public record UpdateIndividualCommand(int IndividualId, IndividualDto Individual, string ClientId) : IRequest<Result<IndividualDto>>;
