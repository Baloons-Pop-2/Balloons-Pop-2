using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class ShowTopScoreCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            ctx.Logger.Log("ShowTopScoreCommand.Execute() invoked - Not implemented!");
            ctx.CurrentMessage = "This command is not yet implemented! Check back later!";
        }
    }
}
