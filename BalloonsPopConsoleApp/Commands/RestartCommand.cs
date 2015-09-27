using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class RestartCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            ctx.Board.Reset();
        }

        public bool CanExecute(ICommandContext ctx)
        {
            return false;
        }
    }
}
