namespace BalloonsPopConsoleApp
{
    using System.Collections.Generic;
    using BalloonsPop;
    using BalloonsPop.Logs;

    public class CommandContext : ICommandContext
    {
        private readonly Dictionary<string, string> messages = new Dictionary<string, string>()
        {
            { "welcome", "\nWelcome to \"Balloons Pops\" game. \r\nTry to pop the balloons in as few moves as possible. \r\nUse 'top' to view the top scoreboard, \r\n'restart' to start a new game and \r\n'exit' to quit the game.\n" },
            { "goodbye", "Goodbye!" },
            { "invalidmove", "\nIllegal move: cannot pop missing ballon!" },
            { "invalidcommand", "\nInvalid move or command!" },
            { "gameover", "\nYou popped all baloons in {0} moves.\r\nPlease enter your name for the top scoreboard: " },
            { "invalidsave", "\nYou cannot restore the game to a previous state as one does not exist yet!" },
            { "sizeprompt", "\nEnter a number between 5 and 15 for the board size \r\nor leave empty if you wish to play with the default size! : " },
            { "inputprompt", "\nEnter a command or valid move in the format \"row column\": " }
        };

        public CommandContext(ILogger logger, IBoard board, int row, int col, IBoardMemory memory, IHighscore score)
        {
            this.Logger = logger;
            this.Board = board;
            this.ActiveRow = row;
            this.ActiveCol = col;
            this.Memory = memory;
            this.Score = score;

            this.CurrentMessage = this.Messages["welcome"];
        }

        public ILogger Logger { get; set; }

        public IBoard Board { get; set; }

        public int ActiveCol { get; set; }

        public int ActiveRow { get; set; }

        public Dictionary<string, string> Messages
        {
            get { return this.messages; }
        }

        public IBoardMemory Memory { get; set; }

        public IHighscore Score { get; set; }

        public string CurrentMessage { get; set; }
    }
}
