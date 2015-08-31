using BalloonsPop.Engine;
using BalloonsPop.UI.ConsoleUI;

namespace BalloonsPopConsoleApp
{
    class Program
    {
        static void Main()
        {
            var consoleUi = new ConsoleUserInterface();
            var engine = new GameEngine(consoleUi);

            engine.Start();
        }
    }
}
