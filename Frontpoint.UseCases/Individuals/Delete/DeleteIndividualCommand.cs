using Ardalis.Result;
using MediatR;

namespace Frontpoint.UseCases.Individuals.Delete;

/// <summary>
/// Delete an individual
/// </summary>
/// <param name="IndividualId"></param>
public record DeleteIndividualCommand(int IndividualId, string ClientId) : IRequest<Result>;
