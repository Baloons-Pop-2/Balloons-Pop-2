namespace BalloonsPop.UI.InputHandler
{
    public interface IInputHandler
    {
        string Read();

        string ParseInput(string input);
    }
}
