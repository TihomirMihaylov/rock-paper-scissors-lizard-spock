using Game.Models;
using Game.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    [ApiController]
    [Route("choices")]
    //[Route("[controller]")] //both will work
    public class ChoicesController : GameController
    {
        private readonly IChoicesService m_ChoicesService;

        public ChoicesController(IChoicesService choicesService)
        {
            m_ChoicesService = choicesService ?? throw new ArgumentNullException(nameof(choicesService));
        }

        public IEnumerable<Choice> Get() => m_ChoicesService.GetAllChoices();
    }
}
