using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class InvalidInputCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            // inform player that the input is not valid
            ctx.CurrentMessage = ctx.Messages["invalidcommand"];
        }
    }
}
