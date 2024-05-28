using Ardalis.Result;
using Ardalis.SharedKernel;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Testing.Common.Fakes;
using Frontpoint.UseCases.Individuals;
using Frontpoint.UseCases.Individuals.Get;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Frontpoint.UnitTests.UseCases.Individuals;

[TestClass, TestCategory("unit")]
public class GetIndividualHandlerTest
{
    private IRepository<Individual> _repository;
    private GetIndividualHandler _handler;

    [TestInitialize]
    public void Initialize()
    {
        _repository = Substitute.For<IRepository<Individual>>();
        _handler = new GetIndividualHandler(_repository, Substitute.For<ILogger<GetIndividualHandler>>());
    }

    [TestMethod]
    public async Task Handle_Found()
    {
        // Arrange
        var query = new GetIndividualQuery(1);
        var indiviual = new IndividualFaker().Generate(1).First();
        var expectedResult = IndividualDto.FromEntity(indiviual);
        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).ReturnsForAnyArgs(indiviual);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(expectedResult, result.Value);
        _ = _repository.Received(1).GetByIdAsync(1, Arg.Any<CancellationToken>());
    }

    [TestMethod]
    public async Task Handle_NotFound()
    {
        // Arrange
        var query = new GetIndividualQuery(1);
        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).ReturnsNullForAnyArgs();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(ResultStatus.NotFound, result.Status);
    }
}
