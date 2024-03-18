using System.Diagnostics.CodeAnalysis;

namespace Application.DTO
{
    [ExcludeFromCodeCoverage]
    public sealed class ElixirInventorReponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}