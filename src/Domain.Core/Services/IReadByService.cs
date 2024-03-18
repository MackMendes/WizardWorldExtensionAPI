namespace Domain.Core.Services
{
    public interface IReadByService<T> where T : class
    {
        /// <summary>
        /// Get elixirs by the list of ingredients 
        /// </summary>
        /// <param name="items">List of ingredients</param>
        /// <returns>All elixirs</returns>
        Task<IEnumerable<T>> GetByAsync(IEnumerable<string> items);
    }
}
