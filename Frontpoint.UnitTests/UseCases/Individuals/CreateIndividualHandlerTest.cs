using Ardalis.SharedKernel;
using FluentAssertions;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Core.Interfaces;
using Frontpoint.Testing.Common.Fakes;
using Frontpoint.UseCases.Individuals;
using Frontpoint.UseCases.Individuals.Create;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;

namespace Frontpoint.UnitTests.UseCases.Individuals;

[TestClass, TestCategory("unit")]
public class CreateIndividualHandlerTest
{
    private IRepository<Individual> _repository;
    private IDateTimeNowProvider _dateTimeNowProvider;
    private CreateIndividualHandler _handler;

    [TestInitialize]
    public void Initialize()
    {
        _repository = Substitute.For<IRepository<Individual>>();
        _dateTimeNowProvider = Substitute.For<IDateTimeNowProvider>();
        _dateTimeNowProvider.UtcNow().Returns(DateTime.UtcNow);
        _handler = new CreateIndividualHandler(_repository, _dateTimeNowProvider, Substitute.For<ILogger<CreateIndividualHandler>>());
    }

    [TestMethod]
    public async Task Handle()
    {
        // Arrange
        var requestDto = new IndividualDtoFaker(0).Generate(1).First();
        var command = new CreateIndividualCommand(requestDto, "user a");

        var response = IndividualDto.ToEntity(requestDto);
        response.Id = 1;

        var expectedArg = IndividualDto.ToEntity(requestDto);
        expectedArg.CreatedBy = "user a";
        expectedArg.CreatedAt = _dateTimeNowProvider.UtcNow();

        var expectedDto = requestDto with { Id = 1 };

        _repository.AddAsync(Arg.Any<Individual>(), Arg.Any<CancellationToken>()).ReturnsForAnyArgs(response);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        result.Value.Should().BeEquivalentTo(expectedDto);
        _ = _repository.Received(1).AddAsync(Verify.That<Individual>(x => x.Should().BeEquivalentTo(expectedArg)), Arg.Any<CancellationToken>());
    }
}
