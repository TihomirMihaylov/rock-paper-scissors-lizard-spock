using Game.Models;

namespace Game.Clients.Interfaces
{
    public interface IRandomProviderClient
    {
        Task<RandomProviderResponse> GetRandomAsync(CancellationToken cancellationToken);
    }
}
