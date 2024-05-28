using Frontpoint.Core.Entities.IndividualAggregate;

namespace Frontpoint.Infrastructure.Data;

public static class SeedData
{
    public static readonly Individual Individual1 = new()
    {
        FirstName = "John",
        LastName = "Doe",
        DateOfBirth = new DateOnly(1987, 3, 25),
        TelephoneNumber = "2345678901",
        AddressLine1 = "123 Right Road",
        City = "Gotham",
        State = "NY",
        Zip = "12345",
        Country = "USA",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = "Seed Data"
    };
    public static readonly Individual Individual2 = new()
    {
        FirstName = "Jane",
        LastName = "Doe",
        DateOfBirth = new DateOnly(1972, 8, 1),
        TelephoneNumber = "3456789012",
        AddressLine1 = "234 Left Road",
        City = "Atlantis",
        State = "GA",
        Zip = "23456",
        Country = "USA",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = "Seed Data"
    };
    public static readonly Individual Individual3 = new()
    {
        FirstName = "John",
        LastName = "Smith",
        DateOfBirth = new DateOnly(1965, 10, 14),
        TelephoneNumber = "4567890123",
        AddressLine1 = "345 Straight Road",
        City = "Metropolis",
        State = "CA",
        Zip = "34567",
        Country = "USA",
        CreatedAt = DateTime.UtcNow,
        CreatedBy = "Seed Data"
    };

    public static void Initialize(FrontpointDbContext dbContext)
    {
        if (dbContext.Individuals.Any()) return;

        dbContext.Individuals.AddRange([Individual1, Individual2, Individual3]);
        dbContext.SaveChanges();
    }
}
