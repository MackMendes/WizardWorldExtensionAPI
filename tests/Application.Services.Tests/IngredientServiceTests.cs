using Application.DTO;
using Domain.Core.Gateways;
using Domain.Model;
using FizzWare.NBuilder;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace Application.Services.Tests
{
    public class IngredientServiceTests
    {
        private readonly Mock<IWizardWorldGateway> mockWizardWorldGateway;
        private readonly Mock<IMemoryCache> mockMemoryCache;
        private readonly IngredientService ingredientService;

        public IngredientServiceTests()
        {
            this.mockWizardWorldGateway = new Mock<IWizardWorldGateway>();
            this.ingredientService = new IngredientService(this.mockWizardWorldGateway.Object);
        }

        [Fact]
        public async Task GetAllAsync_WhenExistsSomeIngredients_ReturnsListOfIngredientExpected()
        {
            // Arrange
            var expectedIngredients = Builder<Ingredient>.CreateListOfSize(3).Build();

            this.mockWizardWorldGateway
                .Setup(x => x.GetAllIngredientsAsync())
                .ReturnsAsync(expectedIngredients);

            // Act
            var result = await this.ingredientService.GetAllAsync();

            // Assert
            Assert.Equal(expectedIngredients.Count(), result.Count());
            this.mockWizardWorldGateway.Verify(x => x.GetAllIngredientsAsync(), Times.Once());
        }

        private IList<Elixir> BuildElixirs(int countOfElixirs, int countOfIngredients, int countOfElixirInventor)
        {
            var listOfElixirs = Builder<Elixir>.CreateListOfSize(countOfElixirs).Build();

            foreach (var elixirs in listOfElixirs)
            {
                elixirs.Ingredients = Builder<Ingredient>.CreateListOfSize(countOfIngredients).Build();
                elixirs.Inventors = Builder<ElixirInventor>.CreateListOfSize(countOfElixirInventor).Build();
            }

            return listOfElixirs;
        }
    }
}