using Application.DTO;
using Domain.Core.Gateways;
using Domain.Core.Services;
using Domain.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace Application.Services
{
    public sealed class ElixirService(IWizardWorldGateway wizardWorldGateway, IMemoryCache memoryCache) : IReadByService<ElixirReponse>
    {
        const int cacheDurationInSeconds = 60;

        private readonly IWizardWorldGateway wizardWorldGateway = wizardWorldGateway;
        private readonly IMemoryCache memoryCache = memoryCache;

        /// <summary>
        /// Get elixirs by the list of ingredients 
        /// </summary>
        /// <param name="items">List of ingredients</param>
        /// <returns>All elixirs</returns>
        public async Task<IEnumerable<ElixirReponse>> GetByAsync(IEnumerable<string> items)
        {
            var cacheKey = this.GetCacheKey(items);

            var request = memoryCache.GetOrCreateAsync(cacheKey, async (factory) =>
            {
                factory.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheDurationInSeconds);
                var elixirs = await this.wizardWorldGateway.GetAllElixirsByListOfIngredientAsync(items);
                return elixirs.Select(Mapping);
            });

            return request?.Result ?? [];
        }

        private static ElixirReponse Mapping(Elixir elixir)
        {
            return new ElixirReponse
            {
                Characteristics = elixir.Characteristics,
                Difficulty = (ElixirDifficultyReponse)elixir.ElixirDifficulty,
                Id = elixir.Id,
                Name = elixir.Name,
                Effect = elixir.Effect,
                Manufacturer = elixir.Manufacturer,
                Time = elixir.Time,
                SideEffects = elixir.SideEffects,
                Inventors = elixir.Inventors.Select(x => new ElixirInventorReponse { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }),
                Ingredients = elixir.Ingredients.Select(x => new IngredientReponse { Id = x.Id, Name = x.Name })
            };
        }

        private string GetCacheKey(IEnumerable<string> items)
        {
            var stringBuilder = new StringBuilder();
            items?.OrderBy(x => x).ToList().ForEach(x => stringBuilder.Append(x));

            return stringBuilder.ToString();
        }
    }
}
