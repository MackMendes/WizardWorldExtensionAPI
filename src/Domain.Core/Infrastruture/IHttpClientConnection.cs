namespace Domain.Core.Infrastruture
{
    public interface IHttpClientConnection
    {
        Task<HttpResponseMessage> GetAsync(string endpoint, CancellationToken cancellationToken);

        Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent? content, CancellationToken cancellationToken);

        Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent? content, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteAsync(string endpoint, CancellationToken cancellationToken);
    }
}
