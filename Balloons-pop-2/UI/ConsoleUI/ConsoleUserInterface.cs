using BalloonsPops.UI.Drawer;
using BalloonsPops.UI.InputHandler;

namespace BalloonsPops.UI.ConsoleUI
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
