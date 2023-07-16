using Game.Clients.Interfaces;
using Game.Enums;
using Game.Models;
using Game.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Game.Services
{
    public class ChoicesService : IChoices
    {
        private readonly IRandomProviderClient m_RandomProviderClient;
        private readonly ILogger<ChoicesService> m_Logger;

        public ChoicesService(IRandomProviderClient randomProviderClient, ILogger<ChoicesService> logger)
        {
            m_RandomProviderClient = randomProviderClient ?? throw new ArgumentNullException(nameof(randomProviderClient));
            m_Logger = logger ?? throw new ArgumentNullException(nameof(logger)); //Do I need to register this
        }

        public IEnumerable<Choice> GetAllChoices()
        {
            var result = new List<Choice>();
            foreach (var symbol in (Symbol[])Enum.GetValues(typeof(Symbol)))
            {
                result.Add(new Choice
                {
                    Id = (int)symbol,
                    Name = symbol.ToString()
                });
            }

            return result;
        }

        public async Task<Choice> GetRandomChoiceAsync(CancellationToken cancellationToken)
        {
            try
            {
                var rnd = await m_RandomProviderClient.GetRandomAsync(cancellationToken);

                return new Choice
                {
                    Id = rnd.Value,
                    Name = ((Symbol)rnd.Value).ToString()
                };
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "Error while fetching random value from provider. Error message: {Message}", ex.Message);

                //use fallback mechanism when API doesn't return a response
                var rndGenerator = new Random();
                var rdnValue = rndGenerator.Next(1, 5);
                return new Choice
                {
                    Id = rdnValue,
                    Name = ((Symbol)rdnValue).ToString()
                };
            }
        }
    }
}
