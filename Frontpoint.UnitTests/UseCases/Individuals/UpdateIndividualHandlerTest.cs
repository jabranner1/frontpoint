using Ardalis.Result;
using Ardalis.SharedKernel;
using FluentAssertions;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Core.Interfaces;
using Frontpoint.Testing.Common.Fakes;
using Frontpoint.UseCases.Individuals;
using Frontpoint.UseCases.Individuals.Update;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using PAP.NSubstitute.FluentAssertionsBridge;

namespace Frontpoint.UnitTests.UseCases.Individuals;

[TestClass, TestCategory("unit")]
public class UpdateIndividualHandlerTest
{
    private IRepository<Individual> _repository;
    private IDateTimeNowProvider _dateTimeNowProvider;
    private UpdateIndividualHandler _handler;

    [TestInitialize]
    public void Initialize()
    {
        _repository = Substitute.For<IRepository<Individual>>();
        _dateTimeNowProvider = Substitute.For<IDateTimeNowProvider>();
        _dateTimeNowProvider.UtcNow().Returns(DateTime.UtcNow);
        _handler = new UpdateIndividualHandler(_repository, _dateTimeNowProvider, Substitute.For<ILogger<UpdateIndividualHandler>>());
    }

    [TestMethod]
    public async Task Handle_Found()
    {
        // Arrange
        var requestDto = new IndividualDtoFaker().Generate(1).First();
        var command = new UpdateIndividualCommand(requestDto.Id, requestDto, "user a");

        var response = new IndividualFaker(1).Generate(1).First();

        var expectedArg = IndividualDto.ToEntity(requestDto);
        expectedArg.Id = 1;
        expectedArg.LastUpdatedBy = "user a";
        expectedArg.LastUpdatedAt = _dateTimeNowProvider.UtcNow();

        var expectedDto = requestDto with { Id = 1 };

        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).ReturnsForAnyArgs(response);
        _repository.UpdateAsync(Arg.Any<Individual>(), Arg.Any<CancellationToken>()).ReturnsForAnyArgs(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        result.Value.Should().BeEquivalentTo(expectedDto);
        _ = _repository.Received(1).GetByIdAsync(1, Arg.Any<CancellationToken>());
        _ = _repository.Received(1).UpdateAsync(Verify.That<Individual>(x => x.Should().BeEquivalentTo(expectedArg)), Arg.Any<CancellationToken>());
    }

    [TestMethod]
    public async Task Handle_NotFound()
    {
        // Arrange
        var requestDto = new IndividualDtoFaker().Generate(1).First();
        var command = new UpdateIndividualCommand(requestDto.Id, requestDto, "user a");

        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).ReturnsNullForAnyArgs();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(ResultStatus.NotFound, result.Status);
    }
}
