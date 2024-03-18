using System.Diagnostics.CodeAnalysis;

namespace Domain.Model
{
    [ExcludeFromCodeCoverage]
    public sealed class Ingredient
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}