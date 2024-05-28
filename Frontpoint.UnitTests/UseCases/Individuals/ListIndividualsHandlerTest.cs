using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Core.Entities.IndividualAggregate.Specifications;
using Frontpoint.Testing.Common.Fakes;
using Frontpoint.UseCases.Individuals;
using Frontpoint.UseCases.Individuals.List;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Frontpoint.UnitTests.UseCases.Individuals;

[TestClass, TestCategory("unit")]
public class ListIndividualsHandlerTest
{
    private IRepository<Individual> _repository;
    private ListIndividualsHandler _handler;

    [TestInitialize]
    public void Initialize()
    {
        _repository = Substitute.For<IRepository<Individual>>();
        _handler = new ListIndividualsHandler(_repository);
    }

    [TestMethod]
    public async Task Handle_Results()
    {
        // Arrange
        var query = new ListIndividualsQuery(5, 10);
        var indiviuals = new IndividualFaker().Generate(5);
        var expectedResults = indiviuals.Select(IndividualDto.FromEntity).ToArray();
        _repository.ListAsync(Arg.Any<PaginateIndiviualsSpec>(), Arg.Any<CancellationToken>()).ReturnsForAnyArgs(indiviuals);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        CollectionAssert.AreEqual(expectedResults, result.Value.ToArray());
        _ = _repository.Received(1).ListAsync(Arg.Is<PaginateIndiviualsSpec>(x => x.Skip == 10 && x.Take == 5), Arg.Any<CancellationToken>());
    }

    [TestMethod]
    public async Task Handle_NoResults()
    {
        // Arrange
        var query = new ListIndividualsQuery(10, 10);
        _repository.ListAsync(Arg.Any<PaginateIndiviualsSpec>(), Arg.Any<CancellationToken>()).ReturnsNullForAnyArgs();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        CollectionAssert.AreEqual(Array.Empty<IndividualDto>(), result.Value.ToArray());
    }
}
