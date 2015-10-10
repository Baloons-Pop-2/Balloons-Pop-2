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

    /// <summary>
    /// A concrete ICommand Implementation that shows the top 5 players and their scores.
    /// </summary>
    public class ShowTopScoreCommand : ICommand
    {
        /// <summary>
        /// Executes the ShowTopScore Command on the passed context.
        /// </summary>
        /// <param name="ctx">The context that contains the Score object</param>
        public void Execute(ICommandContext ctx)
        {
            char separator = '-';
            int sepCount = 15;

            string header = new string(separator, sepCount) + " Top 5 players: " + new string(separator, sepCount) + Environment.NewLine;

            string footer = Environment.NewLine + new string(separator, 2) + " " + new string(separator, 41) + " " + new string(separator, 2) + Environment.NewLine;

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
