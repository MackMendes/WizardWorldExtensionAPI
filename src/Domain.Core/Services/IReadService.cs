namespace Domain.Core.Services
{
    public interface IReadService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
