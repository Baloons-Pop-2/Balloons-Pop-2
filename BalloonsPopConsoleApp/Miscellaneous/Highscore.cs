// <copyright  file="Highscore.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using BalloonsPop;

    /// <summary>
    /// Score object containing information about the player's current moves. Username is set on demand.
    /// </summary>
    public class Highscore : IHighscore
    {
        public const int TheAnswerToEverything = 42;
        private static IHighscore instance;
        
        private Highscore()
        {
        }

        /// <summary>
        /// Increased each time a player makes a move
        /// </summary>
        public int CurrentMoves { get; set; }

        public int CurrentScore { get; private set; }

        /// <summary>
        /// Player's name
        /// </summary>
        public string Username { get; private set; }

        public static IHighscore GetInstance()
        {
            if (instance == null)
            {
                instance = new Highscore();
            }

            return instance;
        }

        /// <summary>
        /// Set Player's Name on demand
        /// </summary>
        /// <param name="name">The current player's identity</param>
        /// <returns>Instance of type Highscore</returns>
        public IHighscore SetUsername(string name)
        {
            this.Username = name;

            return this;
        }
        
        public IHighscore SetMoves(int moves)
        {
            this.CurrentMoves = moves;

            return this;
        }

        public void SetScore(int boardSize)
        {
            int normalizer = 150;
            int score = (boardSize * TheAnswerToEverything / this.CurrentMoves) * normalizer;

            this.CurrentScore = score;
        }
    }
}
