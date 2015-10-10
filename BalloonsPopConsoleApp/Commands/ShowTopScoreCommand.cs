// <copyright  file="ShowTopScoreCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using System;
    using System.Linq;
    using BalloonsPop;
    using BalloonsPop.Commands;

    public class ShowTopScoreCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            string header = "-- Top 5 players: --" + Environment.NewLine;
            string footer = Environment.NewLine + "-- -------------- --" + Environment.NewLine;

            var highscores = ctx.HighscoreProcessor.GetTopHighscores();

            if (highscores.Count() == 0)
            {
                ctx.CurrentMessage = ctx.Messages["noscores"];
            }
            else
            {
                ctx.CurrentMessage = header + string.Join(
                    Environment.NewLine, 
                    highscores.Select(x =>
                    {
                        if (x.Item1.Length > 18)
                        {
                            return new Tuple<string, int>(x.Item1.Substring(0, 15) + "...", x.Item2);
                        }

                        return x;
                    }).Select(x => string.Format("{0,-20} {1}", x.Item1, x.Item2))) + footer;
            }
        }
    }
}
