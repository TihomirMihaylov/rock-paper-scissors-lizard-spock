using System.Net.NetworkInformation;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Game.Clients
{
    public class BaseClient
    {
        private readonly HttpClient m_HttpClient;
        private static readonly JsonSerializer JsonSerializer = new();

        protected BaseClient(string baseAddress)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentNullException(nameof(baseAddress));
            }

            m_HttpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        protected async Task<TResponse> GetAsync<TResponse>(
            string requestUri,
            CancellationToken cancellationToken = default
        )
        {
            using var responseContent = await m_HttpClient.GetAsync(requestUri, cancellationToken);
            if (!responseContent.IsSuccessStatusCode)
            {
                throw new NetworkInformationException((int) responseContent.StatusCode);
            }

            await using var responseStream = await responseContent.Content.ReadAsStreamAsync(cancellationToken);
            return Deserialize<TResponse>(responseStream);
        }

        private static T Deserialize<T>(
            Stream s
        )
        {
            using var streamReader = new StreamReader(s);
            using var jsonReader = new JsonTextReader(streamReader);

            return JsonSerializer.Deserialize<T>(jsonReader);
        }
    }
}
