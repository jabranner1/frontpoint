using Ardalis.SharedKernel;
using FluentAssertions;
using Frontpoint.Core.Entities.IndividualAggregate;
using Frontpoint.Testing.Common.Fakes;
using Microsoft.EntityFrameworkCore;

namespace Frontpoint.IntegrationTests.Data;

[TestClass, TestCategory("integration")]

public class IndividualRepositoryTest : RepositoryBaseTestFixture
{
    private IRepository<Individual> _repository;

    [TestInitialize]
    public void Initialise()
    {
        _repository = GetRepository();
    }


    [TestMethod]
    public async Task AddsIndividual()
    {
        // Arrange
        var individual = new IndividualFaker().Generate(1).First();

        // Act
        await _repository.AddAsync(individual);

        // Assert
        var newIndividual = (await _repository.ListAsync()).FirstOrDefault();
        newIndividual.Should().BeEquivalentTo(individual);
    }

    [TestMethod]
    public async Task UpdatesIndividual()
    {
        // Arrange
        var individual = new IndividualFaker().Generate(1).First();
        await _repository.AddAsync(individual);

        _dbContext.Entry(individual).State = EntityState.Detached; // get a different instance
        var newIndividual = (await _repository.ListAsync()).First();
        Assert.AreNotSame(individual, newIndividual);

        // Act
        newIndividual.FirstName = "A new first name";
        await _repository.UpdateAsync(newIndividual);

        // Assert
        var updatedIndividual = (await _repository.ListAsync()).First();
        updatedIndividual.Should().BeEquivalentTo(newIndividual);
    }

    [TestMethod]
    public async Task DeletesIndividual()
    {
        // Arrange
        var individual = new IndividualFaker().Generate(1).First();
        await _repository.AddAsync(individual);

        // Act
        await _repository.DeleteAsync(individual);

        // Assert
        var individuals = await _repository.ListAsync();
        Assert.AreEqual(0, individuals.Count());
    }
}
