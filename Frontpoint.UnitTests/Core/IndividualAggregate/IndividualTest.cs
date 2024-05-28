using Frontpoint.Core.Entities.IndividualAggregate;

namespace Frontpoint.UnitTests.Core.IndividualAggregate;

[TestClass, TestCategory("unit")]

public class IndividualTest
{
    private Individual _individual;

    private readonly string _prefix = "prefix";
    private readonly string _firstName = "first";
    private readonly string _middleName = "middle";
    private readonly string _lastName = "last";
    private readonly DateOnly _dateOfBirth = new(1987, 3, 1);
    private readonly string _telephoneNumber = "1234567890";
    private readonly string _addressLine1 = "line 1";
    private readonly string _addressLine2 = "line 2";
    private readonly string _city = "city";
    private readonly string _state = "state";
    private readonly string _zip = "12345";
    private readonly string _country = "country";

    [TestInitialize]
    public void Initialize()
    {
        _individual = new Individual(_prefix, _firstName, _middleName, _lastName, _dateOfBirth, _telephoneNumber, _addressLine1, _addressLine2, _city, _state, _zip, _country);
    }


    [TestMethod]
    public void Constructor_InitializePrefix()
    {
        Assert.AreEqual(_prefix, _individual.Prefix);
    }

    [TestMethod]
    public void Constructor_InitializeFirstName()
    {
        Assert.AreEqual(_firstName, _individual.FirstName);
    }

    [TestMethod]
    public void Constructor_InitializeLastName()
    {
        Assert.AreEqual(_lastName, _individual.LastName);
    }

    [TestMethod]
    public void Constructor_InitializeMiddleName()
    {
        Assert.AreEqual(_middleName, _individual.MiddleName);
    }

    [TestMethod]
    public void Constructor_InitializeDateOfBirth()
    {
        Assert.AreEqual(_dateOfBirth, _individual.DateOfBirth);
    }

    [TestMethod]
    public void Constructor_InitializeTelephoneNumber()
    {
        Assert.AreEqual(_telephoneNumber, _individual.TelephoneNumber);
    }

    [TestMethod]
    public void Constructor_InitializeAddressLine1()
    {
        Assert.AreEqual(_addressLine1, _individual.AddressLine1);
    }

    [TestMethod]
    public void Constructor_InitializeAddressLine2()
    {
        Assert.AreEqual(_addressLine2, _individual.AddressLine2);
    }

    [TestMethod]
    public void Constructor_InitializeCity()
    {
        Assert.AreEqual(_city, _individual.City);
    }

    [TestMethod]
    public void Constructor_InitializeState()
    {
        Assert.AreEqual(_state, _individual.State);
    }

    [TestMethod]
    public void Constructor_InitializeZip()
    {
        Assert.AreEqual(_zip, _individual.Zip);
    }

    [TestMethod]
    public void Constructor_InitializeCountry()
    {
        Assert.AreEqual(_country, _individual.Country);
    }
}
