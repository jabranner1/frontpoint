using Bogus;
using Frontpoint.UseCases.Individuals;


namespace Frontpoint.Testing.Common.Fakes;

public record IndividualDtoFake : IndividualDto
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public IndividualDtoFake() : base(default, default, default, default, default, default, default, default, default, default, default, default, default) { }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}

public class IndividualDtoFaker : Faker<IndividualDtoFake>
{
    public IndividualDtoFaker(int id = 1)
    {
        RuleFor(x => x.Id, _ => id++);
        RuleFor(x => x.FirstName, x => x.Random.Words());
        RuleFor(x => x.LastName, x => x.Random.Words());
        RuleFor(x => x.DateOfBirth, x => x.Date.BetweenDateOnly(new DateOnly(1940, 1, 1), new DateOnly(2010, 1, 1)));
        RuleFor(x => x.TelephoneNumber, x => x.Phone.PhoneNumber());
        RuleFor(x => x.AddressLine1, x => x.Address.StreetAddress());
        RuleFor(x => x.City, x => x.Address.City());
        RuleFor(x => x.State, x => x.Address.State());
        RuleFor(x => x.Zip, x => x.Address.ZipCode());
        RuleFor(x => x.Country, x => x.Address.Country());
    }
}
