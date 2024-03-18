using System.Diagnostics.CodeAnalysis;

namespace Application.DTO
{
    [ExcludeFromCodeCoverage]
    public sealed class ElixirReponse
    {
        public ElixirReponse()
        {
            this.Ingredients = new List<IngredientReponse>(); 
            this.Inventors = new List<ElixirInventorReponse>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Effect { get; set; }

        public string SideEffects { get; set; }

        public string Characteristics { get; set; }

        public string Time { get; set; }

        public ElixirDifficultyReponse Difficulty { get; set; }

        public IEnumerable<IngredientReponse> Ingredients { get; set; }

        public IEnumerable<ElixirInventorReponse> Inventors { get; set; }

        public string Manufacturer { get; set; }
    }
}
