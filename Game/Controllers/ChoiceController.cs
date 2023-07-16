using Game.Models;
using Game.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    [ApiController]
    [Route("choice")]
    public class ChoiceController : GameController
    {
        
        private readonly IChoicesService m_ChoicesService;

        public ChoiceController(IChoicesService choicesService)
        {
            m_ChoicesService = choicesService ?? throw new ArgumentNullException(nameof(choicesService));
        }

        public async Task<Choice> Get() => await m_ChoicesService.GetRandomChoiceAsync(Cts.Token);
    }
}
