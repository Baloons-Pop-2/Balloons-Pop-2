namespace BalloonsPop.UI.InputHandler
{
    public interface IInputHandler
    {
        string Read();

        bool VerifyInput(string input);
    }
}
