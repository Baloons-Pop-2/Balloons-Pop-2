// <copyright  file="RestartCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

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
            ctx.Score.SetMoves(0);
            ctx.CurrentMessage = ctx.Messages[WelcomeMessageKey];

            ctx.Logger.Log(string.Format("Started new game at: {0}", DateTime.Now));
        }
    }
}
