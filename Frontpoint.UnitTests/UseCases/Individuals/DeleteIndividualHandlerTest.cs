using Ardalis.Result;
using Ardalis.SharedKernel;
using FluentAssertions;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Testing.Common.Fakes;
using Frontpoint.UseCases.Individuals.Delete;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using PAP.NSubstitute.FluentAssertionsBridge;

namespace Frontpoint.UnitTests.UseCases.Individuals;

[TestClass, TestCategory("unit")]
public class DeleteIndividualHandlerTest
{
    private IRepository<Individual> _repository;
    private DeleteIndividualHandler _handler;

    [TestInitialize]
    public void Initialize()
    {
        _repository = Substitute.For<IRepository<Individual>>();
        _handler = new DeleteIndividualHandler(_repository, Substitute.For<ILogger<DeleteIndividualHandler>>());
    }

    [TestMethod]
    public async Task Handle_Found()
    {
        // Arrange
        var command = new DeleteIndividualCommand(1, "user a");
        var response = new IndividualFaker(1).Generate(1).First();

        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).ReturnsForAnyArgs(response);
        _repository.DeleteAsync(Arg.Any<Individual>(), Arg.Any<CancellationToken>()).ReturnsForAnyArgs(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        _ = _repository.Received(1).GetByIdAsync(1, Arg.Any<CancellationToken>());
        _ = _repository.Received(1).DeleteAsync(Verify.That<Individual>(x => x.Should().BeEquivalentTo(response)), Arg.Any<CancellationToken>());
    }

    [TestMethod]
    public async Task Handle_NotFound()
    {
        // Arrange
        var command = new DeleteIndividualCommand(1, "user a");

        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).ReturnsNullForAnyArgs();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(ResultStatus.NotFound, result.Status);
    }
}
