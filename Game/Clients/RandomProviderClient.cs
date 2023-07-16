using Game.Clients.Interfaces;
using Game.Models;
using Microsoft.Extensions.Options;

namespace Game.Clients
{
    public class RandomProviderClient : BaseClient, IRandomProviderClient
    {
        public RandomProviderClient(IOptionsMonitor<Configuration> configuration) 
            : base(configuration.CurrentValue.RandomProviderUrl) { }

        public async Task<RandomProviderResponse> GetRandomAsync(CancellationToken cancellationToken)
            => await GetAsync<RandomProviderResponse>("/random", cancellationToken);
    }
}
