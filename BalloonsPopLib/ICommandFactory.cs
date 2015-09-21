using BalloonsPop.Commands;

namespace BalloonsPop
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string command);
    }
}
