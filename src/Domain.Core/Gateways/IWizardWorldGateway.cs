using Domain.Model;

namespace Domain.Core.Gateways
{
    public interface IWizardWorldGateway
    {
        Task<IEnumerable<Elixir>> GetAllElixirsAsync();

        Task<IEnumerable<Elixir>> GetAllElixirsByIngredientAsync(string ingredientName);

        Task<IEnumerable<Elixir>> GetAllElixirsByListOfIngredientAsync(IEnumerable<string> ingredientsName);

        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
    }
}
