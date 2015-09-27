using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class ShowTopScoreCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            throw new System.NotImplementedException();
        }

        public bool CanExecute(ICommandContext ctx)
        {
            return false;
        }
    }
}
