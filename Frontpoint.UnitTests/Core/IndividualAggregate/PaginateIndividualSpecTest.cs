using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Core.Entities.IndividualAggregate.Specifications;
using Frontpoint.Testing.Common.Fakes;

namespace Frontpoint.UnitTests.Core.IndividualAggregate;

[TestClass, TestCategory("unit")]
public class PaginateIndividualSpecTest
{
    [TestMethod]
    public void Constructor_DefaultValues()
    {
        // Arrange
        var individuals = new IndividualFaker().Generate(20);
        var expected = GetExpectedIndividuals(individuals);
        var spec = new PaginateIndiviualsSpec();

        // Act
        var result = spec.Evaluate(individuals).ToArray();

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Constructor_Take5()
    {
        // Arrange
        var individuals = new IndividualFaker().Generate(20);
        var expected = GetExpectedIndividuals(individuals, 5);
        var spec = new PaginateIndiviualsSpec(5);

        // Act
        var result = spec.Evaluate(individuals).ToArray();

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Constructor_Skip5()
    {
        // Arrange
        var individuals = new IndividualFaker().Generate(20);
        var expected = GetExpectedIndividuals(individuals, 10, 5);
        var spec = new PaginateIndiviualsSpec(null, 5);

        // Act
        var result = spec.Evaluate(individuals).ToArray();

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Constructor_Take5_Skip5()
    {
        // Arrange
        var individuals = new IndividualFaker().Generate(20);
        var expected = GetExpectedIndividuals(individuals, 5, 5);
        var spec = new PaginateIndiviualsSpec(5, 5);

        // Act
        var result = spec.Evaluate(individuals).ToArray();

        // Assert
        CollectionAssert.AreEqual(expected, result);

    }

    private static Individual[] GetExpectedIndividuals(IEnumerable<Individual> individuals, int take = 10, int skip = 0)
    {
        return individuals.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).Skip(skip).Take(take).ToArray();
    }
}
