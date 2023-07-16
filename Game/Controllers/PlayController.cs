using Game.Models;
using Game.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    [ApiController]
    [Route("play")]
    public class PlayController : GameController
    {
        private readonly IPlayService m_PlayService;

        public PlayController(IPlayService playService)
        {
            m_PlayService = playService ?? throw new ArgumentNullException(nameof(playService));
        }

        public async Task<PlayResponse> Post(PlayRequest request) => await m_PlayService.PlayAgainstBot(request.Player, Cts.Token);
    }
}
