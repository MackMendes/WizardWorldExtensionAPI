using Domain.Core.Gateways;
using Domain.Core.Infrastruture;
using Domain.Model;
using System.Text.Json;

namespace Data.Gateway
{
    public sealed class WizardWorldGateway(IHttpClientConnection httpClientConnection, int defaultTimeoutInMilliseconds) : IWizardWorldGateway
    {
        const string elixirsEnpoint = "elixirs";
        const string ingredientsEnpoint = "ingredients";

        private readonly IHttpClientConnection httpClientConnection = httpClientConnection;
        private readonly int defaultTimeoutInMilliseconds = defaultTimeoutInMilliseconds;

        public async Task<IEnumerable<Elixir>> GetAllElixirsAsync()
        {
            var response = await httpClientConnection.GetAsync(elixirsEnpoint, GetCancellationToken());
            var elixirs = new List<Elixir>();
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStreamAsync();
                elixirs = await JsonSerializer.DeserializeAsync<List<Elixir>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return elixirs ?? [];
        }

        public async Task<IEnumerable<Elixir>> GetAllElixirsByIngredientAsync(string ingredientName)
        {
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                return [];
            }

            var response = await httpClientConnection.GetAsync($"{elixirsEnpoint}?Ingredient={ingredientName}", GetCancellationToken());

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStreamAsync();

                if (content != null && content.Length > 0)
                    return await JsonSerializer.DeserializeAsync<List<Elixir>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return [];
        }

        public async Task<IEnumerable<Elixir>> GetAllElixirsByListOfIngredientAsync(IEnumerable<string> ingredientsName)
        {
            var elixirs = new List<Elixir>();
            for (int i = 0, count = ingredientsName.Count(); i < count; i++)
            {
                var elixirsResponse = await this.GetAllElixirsByIngredientAsync(ingredientsName.ElementAt(i));

                if (elixirsResponse == null || !elixirsResponse.Any())
                    continue;

                // To remove repeated Elixirs, we can also do it this way:
                //if (elixirs.Count >= 1)
                //    elixirs.AddRange(elixirsResponse.Where(x => !elixirsResponse.Any(y => y.Id == x.Id)));
                //else

                elixirs.AddRange(elixirsResponse);
            }
            
            return elixirs.DistinctBy(x => x.Id);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            var response = await httpClientConnection.GetAsync(ingredientsEnpoint, GetCancellationToken());
            var ingredients = new List<Ingredient>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStreamAsync();
                ingredients = await JsonSerializer.DeserializeAsync<List<Ingredient>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return ingredients ?? [];
        }

        private CancellationToken GetCancellationToken()
        {
            var cancellationToken = new CancellationTokenSource(this.defaultTimeoutInMilliseconds);
            return cancellationToken.Token;
        }
    }
}
