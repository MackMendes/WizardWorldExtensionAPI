using Domain.Core.Infrastruture;

namespace Infrastructure.CrossCutting
{
    public sealed class HttpClientConnection(HttpClient httpClient, Uri baseUriApi) : IHttpClientConnection
    {
        private readonly HttpClient httpClient = httpClient;
        private readonly Uri baseUriApi = baseUriApi;

        public async Task<HttpResponseMessage> GetAsync(string endpoint, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync(new Uri(this.baseUriApi, endpoint), cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent? content, CancellationToken cancellationToken)
        {
            var response = await httpClient.PostAsync(new Uri(this.baseUriApi, endpoint), content, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent? content, CancellationToken cancellationToken)
        {
            var response = await httpClient.PutAsync(new Uri(this.baseUriApi, endpoint), content, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint, CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteAsync(new Uri(this.baseUriApi, endpoint), cancellationToken);
            return response;
        }
    }
}
