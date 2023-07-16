using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    public class GameController : ControllerBase, IDisposable
    {
        protected readonly CancellationTokenSource Cts;

        public GameController()
        {
            Cts = new CancellationTokenSource();
        }

        public void Dispose()
        {
            Cts.Cancel();
            Cts.Dispose();
        }
    }
}
