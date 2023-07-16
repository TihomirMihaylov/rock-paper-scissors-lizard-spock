using Game.Models;

namespace Game.Services.Interfaces
{
    public interface IChoices
    {
        //in real world app these will be an async method fetching data from a DB
        IEnumerable<Choice> GetAllChoices();

        Task<Choice> GetRandomChoiceAsync(CancellationToken cancellationToken);
    }
}
