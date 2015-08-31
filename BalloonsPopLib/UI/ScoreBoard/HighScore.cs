using System;
using System.Collections.Generic;
using System.Linq;

namespace BalloonsPop.UI.ScoreBoard
{
    public class HighScore
    {
        private const int topMember = 5;
        private List<ScoreResult> scoreboard = new List<ScoreResult>();

        public HighScore()
        {
        }

        public void AddScore(ScoreResult score)
        {
            if (score == null)
            {
                throw new ArgumentNullException("Cannot store null for score.");
            }

            this.scoreboard.Add(score);
        }

        public void Ranking()
        {
            if (this.scoreboard.Count == 0)
            {
                Console.WriteLine("No results.");
            }

            this.scoreboard.Sort();

            var i = 1;
            foreach (var player in this.scoreboard)
            {
                if (i > 5)
                {
                    break;
                }

                Console.WriteLine("{0} -> {1,15}: {2} point(s)", i, player.Username, player.Score);
                i++;
            }
        }
    }
}
