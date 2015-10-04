namespace BalloonsPop.UI
{
    using Drawer;
    using InputHandler;

    public interface IUserInterface
    {
        IPicasso Drawer { get; }

        IInputHandler Reader { get; }
    }
}
