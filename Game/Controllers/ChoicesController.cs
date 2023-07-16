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
        private readonly IChoices m_ChoicesService;

        public ChoicesController(IChoices choicesService)
        {
            m_ChoicesService = choicesService ?? throw new ArgumentNullException(nameof(choicesService));
        }

        public IEnumerable<Choice> Get()
        {
            return m_ChoicesService.GetAllChoices();
        }
    }
}
