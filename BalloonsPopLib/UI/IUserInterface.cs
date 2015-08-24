using BalloonsPop.UI.Drawer;
using BalloonsPop.UI.InputHandler;

namespace BalloonsPop.UI
{
    public interface IUserInterface
    {
        IPicasso Drawer { get; }
        IInputHandler Reader { get; }
    }
}
