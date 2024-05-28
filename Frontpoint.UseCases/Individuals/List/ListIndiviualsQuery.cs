using Ardalis.Result;
using MediatR;

namespace Frontpoint.UseCases.Individuals.List;

/// <summary>
/// List individuals
/// </summary>
/// <param name="Take"></param>
/// <param name="Skip"></param>
public record ListIndividualsQuery(int? Take, int? Skip) : IRequest<Result<IEnumerable<IndividualDto>>>;
