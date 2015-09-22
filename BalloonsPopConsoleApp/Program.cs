using BalloonsPopConsoleApp.Engine;
using BalloonsPopConsoleApp.UI.ConsoleUI;

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
