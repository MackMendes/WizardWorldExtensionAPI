using System.Diagnostics.CodeAnalysis;

namespace Domain.Model
{
    [ExcludeFromCodeCoverage]
    public sealed class Elixir
    {
        public Elixir()
        {
            this.Ingredients = new List<Ingredient>(); 
            this.Inventors = new List<ElixirInventor>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Effect { get; set; }

        public string SideEffects { get; set; }

        public string Characteristics { get; set; }

        public string Time { get; set; }

        public string Difficulty { get; set; }

        public ElixirDifficulty ElixirDifficulty { get { return (ElixirDifficulty)Enum.Parse(typeof(ElixirDifficulty), this.Difficulty); } }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<ElixirInventor> Inventors { get; set; }

        public string Manufacturer { get; set; }
    }
}
