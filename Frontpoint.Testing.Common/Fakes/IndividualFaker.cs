using Bogus;
using Frontpoint.Core.Entities.IndividualAggregate;

namespace Frontpoint.Testing.Common.Fakes;

public class IndividualFaker : Faker<Individual>
{
    public IndividualFaker(int id = 1)
    {
        RuleFor(x => x.Id, _ => id++);
        RuleFor(x => x.Prefix, x => x.Random.Words());
        RuleFor(x => x.FirstName, x => x.Random.Words());
        RuleFor(x => x.MiddleName, x => x.Random.Words());
        RuleFor(x => x.LastName, x => x.Random.Words());
        RuleFor(x => x.DateOfBirth, x => x.Date.BetweenDateOnly(new DateOnly(1940, 1, 1), new DateOnly(2010, 1, 1)));
        RuleFor(x => x.TelephoneNumber, x => x.Phone.PhoneNumber());
        RuleFor(x => x.AddressLine1, x => x.Address.StreetAddress());
        RuleFor(x => x.AddressLine2, x => x.Address.SecondaryAddress());
        RuleFor(x => x.City, x => x.Address.City());
        RuleFor(x => x.State, x => x.Address.State());
        RuleFor(x => x.Zip, x => x.Address.ZipCode());
        RuleFor(x => x.Country, x => x.Address.Country());
    }
}
