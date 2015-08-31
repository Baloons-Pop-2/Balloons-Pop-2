using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPops.UI.ScoreBoard
{
    public class ScoreResult : IComparable<ScoreResult>
    {
        private const int maxScorePoints = 200;
        private const int rate = 10;

        private string username;
        private int score;

        public ScoreResult(string username, int moves)
        {
            this.Username = username;
            this.Score = moves;
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name or nickname, cannot be null.");
                }

                this.username = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Moves cannot be negative.");
                }

                // TODO: More interesting algorithm for score result
                var result = (maxScorePoints - value) * rate;
                this.score = (result < 0 ? 0 : result);
            }
        }

        public int CompareTo(ScoreResult other)
        {
            if (this.Score == other.Score)
            {
                return this.Username.CompareTo(other.Username);
            }

            // High to Low order
            return other.Score.CompareTo(this.Score);
        }
    }
}
