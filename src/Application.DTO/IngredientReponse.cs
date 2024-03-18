using System.Diagnostics.CodeAnalysis;

namespace Application.DTO
{
    [ExcludeFromCodeCoverage]
    public sealed class IngredientReponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}