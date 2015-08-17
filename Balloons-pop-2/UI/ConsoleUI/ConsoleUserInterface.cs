using BalloonsPops.UI.Drawer;
using BalloonsPops.UI.InputHandler;

namespace BalloonsPops.UI.ConsoleUI
{
    class ConsoleUserInterface : IUserInterface
    {
        public IPicasso Drawer
        {
            get { throw new System.NotImplementedException(); }
        }

        public IInputHandler Reader
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
