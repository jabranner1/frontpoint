using Ardalis.Result;
using MediatR;

namespace Frontpoint.UseCases.Individuals.Get;

/// <summary>
/// Get an individual
/// </summary>
/// <param name="IndividualId"></param>
public record GetIndividualQuery(int IndividualId) : IRequest<Result<IndividualDto>>;
