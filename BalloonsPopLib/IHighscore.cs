namespace BalloonsPop
{
    public interface IHighscore
    {
        // PLACEHOLDER: 
        int CurrentMoves { get; set; }

        int CurrentScore { get; }

        string Username { get; }

        IHighscore SetUsername(string name);
        IHighscore SetMoves(int score);
        void SetScore(int boardSize);
    }
}
