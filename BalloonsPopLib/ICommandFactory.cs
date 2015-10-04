namespace BalloonsPop
{
    using Commands;

    public interface ICommandFactory
    {
        ICommand GetCommand(string command);
    }
}
