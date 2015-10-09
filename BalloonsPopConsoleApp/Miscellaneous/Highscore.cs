namespace BalloonsPopConsoleApp.Miscellaneous
{
    using BalloonsPop;

    /// <summary>
    /// Score object containing information about the player's current moves. Username is set on demand.
    /// </summary>
    public class Highscore : IHighscore
    {
        /// <summary>
        /// Increased each time a player makes a move
        /// </summary>
        public int CurrentScore { get; set; }

        /// <summary>
        /// Player's name
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Set Player's Name on demand
        /// </summary>
        /// <param name="name">The current player's identity</param>
        /// <returns>Instance of type Highscore</returns>
        public Highscore PlayerName(string name)
        {
            this.Username = name;

            return this;
        }
    }
}
