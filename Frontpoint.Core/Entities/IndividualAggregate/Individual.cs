using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using System.Diagnostics.CodeAnalysis;

namespace Frontpoint.Core.Entities.IndividualAggregate;

public class Individual : Common.EntityBase, IAggregateRoot
{
    public Individual() { }

    [SetsRequiredMembers]
    public Individual(
        string? prefix,
        string firstName,
        string? middleName,
        string lastName,
        DateOnly dateOfBirth,
        string telephoneNumber,
        string addressLine1,
        string? addressLine2,
        string city,
        string state,
        string zip,
        string country)
    {
        Prefix = prefix;
        FirstName = Guard.Against.NullOrEmpty(firstName);
        MiddleName = middleName;
        LastName = Guard.Against.NullOrEmpty(lastName);
        DateOfBirth = Guard.Against.Null(dateOfBirth);
        TelephoneNumber = Guard.Against.NullOrEmpty(telephoneNumber);
        AddressLine1 = Guard.Against.NullOrEmpty(addressLine1);
        AddressLine2 = addressLine2;
        City = Guard.Against.NullOrEmpty(city);
        State = Guard.Against.NullOrEmpty(state);
        Zip = Guard.Against.NullOrEmpty(zip);
        Country = Guard.Against.NullOrEmpty(country);
    }


    public string? Prefix { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required string TelephoneNumber { get; set; }
    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Zip { get; set; }
    public required string Country { get; set; }
}
