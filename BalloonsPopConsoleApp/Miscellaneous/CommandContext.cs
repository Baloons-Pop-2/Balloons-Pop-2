// <copyright  file="CommandContext.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using System.Collections.Generic;
    using BalloonsPop;
    using BalloonsPop.Logs;

    /// <summary>
    /// Provides common interface to be used by all Commands.
    /// </summary>
    public class CommandContext : ICommandContext
    {
        private readonly Dictionary<string, string> messages = new Dictionary<string, string>()
        {
            { "welcome",  "\nWelcome to \"Balloons Pops\" game. \r\nTry to pop the balloons in as few moves as possible. \r\nUse 'top' to view the top scoreboard, \r\n'restart' to start a new game and \r\n'exit' to quit the game.\n" },
            { "goodbye", "\nHope to see you soon!\nGoodbye! \n\n" },
            { "invalidmove", "\nIllegal move: cannot pop missing ballon!\n" },
            { "invalidcommand", "\nInvalid move or command!\n" },
            { "gameover", "\nYou popped all baloons in {0} moves.\r\nPlease enter your name for the top scoreboard: " },
            { "invalidsave", "\nYou cannot restore the game to a previous state as one does not exist yet!\n" },
            { "sizeprompt", "\nEnter a number between 5 and 15 for the board size \r\nor leave empty if you wish to play with the default size! : " },
            { "inputprompt", "\nEnter a command or valid move in the format \"row column\": " },
            { "usernameprompt", "\nEnter username:" },
            { "noscores", "\nNo highscores yet!\n" }
        };

        /// <summary>
        /// Initializes a new instance of the CommandContext class.
        /// </summary>
        /// <param name="logger">The logger to save messages</param>
        /// <param name="board">The board object to be used in the game</param>
        /// <param name="row">The row that needs to be popped</param>
        /// <param name="col">The column that needs to be popped</param>
        /// <param name="memory">The memory caretaker where a memento is saved</param>
        /// <param name="score">The score container</param>
        public CommandContext(ILogger logger, IBoard board, int row, int col, IBoardMemory memory, IHighscore score, IHighscoreProcessor highscoreProcessor)
        {
            this.Logger = logger;
            this.Board = board;
            this.ActiveRow = row;
            this.ActiveCol = col;
            this.Memory = memory;
            this.Score = score;
            this.HighscoreProcessor = highscoreProcessor;
            this.IsOver = false;

            this.CurrentMessage = this.Messages["welcome"];
        }

        /// <summary>
        /// Gets or sets the logger;
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets the board holding the balloon objects.
        /// </summary>
        public IBoard Board { get; set; }

        /// <summary>
        /// Gets or sets the currently active column.
        /// </summary>
        public int ActiveCol { get; set; }

        /// <summary>
        /// Gets or sets the currently active row.
        /// </summary>
        public int ActiveRow { get; set; }

        /// <summary>
        /// Gets the dictionary containing all messages that can be displayed alongside the game board.
        /// </summary>
        public Dictionary<string, string> Messages
        {
            get { return this.messages; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary>
        public bool IsOver { get; set; }

        /// <summary>
        /// Gets or sets the memento object for the board.
        /// </summary>
        public IBoardMemory Memory { get; set; }

        /// <summary>
        /// Gets or sets the player's high score.
        /// </summary>
        public IHighscore Score { get; set; }

        /// <summary>
        /// Gets or sets the last command output message.
        /// </summary>
        public string CurrentMessage { get; set; }

        /// <summary>
        /// Gets the high score processor.
        /// </summary>
        public IHighscoreProcessor HighscoreProcessor { get; private set; }
    }
}
