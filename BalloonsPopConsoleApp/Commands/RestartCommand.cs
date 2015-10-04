namespace BalloonsPopConsoleApp.Commands
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Commands;

    public class RestartCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            ctx.Board.Reset();
            ctx.Score.CurrentScore = 0;
            ctx.CurrentMessage = ctx.Messages["welcome"];

            ctx.Logger.Log(string.Format("Started new game at: {0}", DateTime.Now));
        }
    }
}
