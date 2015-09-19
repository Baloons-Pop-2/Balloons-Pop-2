using BalloonsPop.UI.ConsoleUI;
using BalloonsPopConsoleApp.Engine;

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
