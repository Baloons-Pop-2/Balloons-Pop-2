using BalloonsPop.UI;
using BalloonsPop.UI.Drawer;
using BalloonsPop.UI.InputHandler;

namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    public class ConsoleUserInterface : IUserInterface
    {
        public ConsoleUserInterface()
        {
            this.Drawer = new ConsoleDrawer();
            this.Reader = new ConsoleInputHandler();
        }

        public IPicasso Drawer { get; private set; }

        public IInputHandler Reader { get; private set; }
    }
}
