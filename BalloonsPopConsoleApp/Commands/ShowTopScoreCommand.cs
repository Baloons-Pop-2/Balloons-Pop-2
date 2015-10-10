namespace BalloonsPopConsoleApp.Commands
{
    using System.Linq;

    using BalloonsPop;
    using BalloonsPop.Commands;
    using System;

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
                ctx.CurrentMessage = header + string.Join(Environment.NewLine, highscores.Select(x => {
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
