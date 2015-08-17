using BalloonsPops.UI.Drawer;
using BalloonsPops.UI.InputHandler;

namespace BalloonsPops.UI
{
    public interface IUserInterface
    {
        IPicasso Drawer { get; }
        IInputHandler Reader { get; }
    }
}
