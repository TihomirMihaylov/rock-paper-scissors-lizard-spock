using Game.Enums;
using Game.Models;

namespace Game.Services.Interfaces
{
    public interface IPlayService
    {
        Task<PlayResponse> PlayAgainstBot(Symbol playerChoice, CancellationToken cancellationToken);
    }
}
