using Frontpoint.Core.Entities.IndividualAggregate;

namespace Frontpoint.UseCases.Individuals;

public record IndividualDto(
    int Id,
    string? Prefix,
    string FirstName,
    string? MiddleName,
    string LastName,
    DateOnly DateOfBirth,
    string TelephoneNumber,
    string AddressLine1,
    string? AddressLine2,
    string City,
    string State,
    string Zip,
    string Country
)
{

    /// <summary>
    /// Maps dto to entity
    /// </summary>
    /// <param name="individual"></param>
    /// <returns></returns>
    public static Individual ToEntity(IndividualDto individual)
    {
        return new Individual(
           individual.Prefix,
           individual.FirstName,
           individual.MiddleName,
           individual.LastName,
           individual.DateOfBirth,
           individual.TelephoneNumber,
           individual.AddressLine1,
           individual.AddressLine2,
           individual.City,
           individual.State,
           individual.Zip,
           individual.Country);
    }

    /// <summary>
    /// Maps entity to dto
    /// </summary>
    /// <param name="individaul"></param>
    /// <returns></returns>
    public static IndividualDto FromEntity(Individual individaul)
    {
        return new IndividualDto(
            individaul.Id,
            individaul.Prefix,
            individaul.FirstName,
            individaul.MiddleName,
            individaul.LastName,
            individaul.DateOfBirth,
            individaul.TelephoneNumber,
            individaul.AddressLine1,
            individaul.AddressLine2,
            individaul.City,
            individaul.State,
            individaul.Zip,
            individaul.Country);
    }
}
