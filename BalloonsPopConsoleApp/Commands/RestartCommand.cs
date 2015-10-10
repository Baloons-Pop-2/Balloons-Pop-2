namespace BalloonsPopConsoleApp.Commands
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Commands;

    public class RestartCommand : ICommand
    {
        public const string WelcomeMessageKey = "welcome";
        public void Execute(ICommandContext ctx)
        {
            ctx.Board.Reset();
            ctx.Score.CurrentMoves = 0;
            ctx.CurrentMessage = ctx.Messages[WelcomeMessageKey];

            ctx.Logger.Log(string.Format("Started new game at: {0}", DateTime.Now));
        }
    }
}
