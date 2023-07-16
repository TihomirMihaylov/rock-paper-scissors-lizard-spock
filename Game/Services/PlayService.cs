using System.ComponentModel;
using Game.Enums;
using Game.Models;
using Game.Services.Interfaces;

namespace Game.Services
{
    public class PlayService : IPlayService
    {
        private readonly IChoicesService m_ChoicesService;

        public PlayService(IChoicesService choicesService)
        {
            m_ChoicesService = choicesService ?? throw new ArgumentNullException(nameof(choicesService));
        }

        public async Task<PlayResponse> PlayAgainstBot(Symbol playerChoice, CancellationToken cancellationToken)
        {
            var botChoice = await m_ChoicesService.GetRandomChoiceAsync(cancellationToken);
            var result = EvaluateGameResult(playerChoice, (Symbol)botChoice.Id);

            return new PlayResponse
            {
                Results = result,
                Player = (int)playerChoice,
                Bot = botChoice.Id
            };
        }

        private static string EvaluateGameResult(Symbol playerChoice, Symbol botChoice)
        {
            if (playerChoice == botChoice)
            {
                return "tie";
            }

            switch (playerChoice)
            {
                case Symbol.Rock:
                    if (botChoice is Symbol.Scissors or Symbol.Lizard)
                    {
                        return "win";
                    }
                    if (botChoice is Symbol.Paper or Symbol.Spock)
                    {
                        return "lose";
                    }
                    break;
                case Symbol.Paper:
                    if (botChoice is Symbol.Rock or Symbol.Spock)
                    {
                        return "win";
                    }
                    if (botChoice is Symbol.Scissors or Symbol.Lizard)
                    {
                        return "lose";
                    }
                    break;
                case Symbol.Scissors:
                    if (botChoice is Symbol.Paper or Symbol.Lizard)
                    {
                        return "win";
                    }
                    if (botChoice is Symbol.Rock or Symbol.Spock)
                    {
                        return "lose";
                    }
                    break;
                case Symbol.Lizard:
                    if (botChoice is Symbol.Spock or Symbol.Paper)
                    {
                        return "win";
                    }
                    if (botChoice is Symbol.Rock or Symbol.Scissors)
                    {
                        return "lose";
                    }
                    break;
                case Symbol.Spock:
                    if (botChoice is Symbol.Scissors or Symbol.Rock)
                    {
                        return "win";
                    }
                    if (botChoice is Symbol.Lizard or Symbol.Paper)
                    {
                        return "lose";
                    }
                    break;
            }

            throw new InvalidEnumArgumentException("Invalid arguments passed to function");
        }
    }
}
