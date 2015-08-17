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

            // engine.Start();
            Game.Start();
        }
    }
}
