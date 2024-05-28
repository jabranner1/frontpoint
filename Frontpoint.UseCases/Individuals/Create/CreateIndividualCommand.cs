using Ardalis.Result;
using MediatR;

namespace Frontpoint.UseCases.Individuals.Create;

/// <summary>
/// Create a new individual
/// </summary>
/// <param name="Individual"></param>
public record CreateIndividualCommand(IndividualDto Individual, string ClientId) : IRequest<Result<IndividualDto>>;
