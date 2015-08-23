using System;

namespace BalloonsPops.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute(CommandContext ctx)
        {
            Environment.Exit(0);
        }
    }
}
