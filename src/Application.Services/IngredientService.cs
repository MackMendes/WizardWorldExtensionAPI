using Application.DTO;
using Domain.Core.Gateways;
using Domain.Core.Services;
using Domain.Model;

namespace Application.Services
{
    public sealed class IngredientService(IWizardWorldGateway wizardWorldGateway) : IReadService<IngredientReponse>
    {
        private readonly IWizardWorldGateway wizardWorldGateway = wizardWorldGateway;

        /// <summary>
        /// Get elixirs by the list of ingredients 
        /// </summary>
        /// <param name="items">List of ingredients</param>
        /// <returns>All elixirs</returns>
        public async Task<IEnumerable<IngredientReponse>> GetAllAsync()
        {
            var elixirs = await this.wizardWorldGateway.GetAllIngredientsAsync();

            return elixirs.Select(Mapping);
        }

        private static IngredientReponse Mapping(Ingredient ingredient)
        {
            return new IngredientReponse
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }
    }
}
