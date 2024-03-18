using System.Diagnostics.CodeAnalysis;

namespace Domain.Model
{
    [ExcludeFromCodeCoverage]
    public sealed class ElixirInventor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}