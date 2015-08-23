using BalloonsPops.UI.ConsoleUI;
using BalloonsPops.Engine;

namespace BalloonsPops
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleUi = new ConsoleUserInterface();
            var engine = new GameEngine(consoleUi);
            var game = new Game();

            // engine.Start();
            game.Start();
        }
    }
}
