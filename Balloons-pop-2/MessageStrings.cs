namespace BalloonsPops
{
    public static class MessageStrings
    {
        private static string welcome = "Welcome to \"Balloons Pops\" game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private static string invalidMoveOrCommand = "Invalid move or command";
        private static string missingBalloonPop = "Illegal move: cannot pop missing ballon!";
        private static string goodbye = "Good Bye";
        private static string enterInput = "Enter a row and column: ";

        public static string Welcome
        {
            get
            {
                return welcome;
            }
        }

        public static string IvalidMoveOrCommand
        {
            get
            {
                return invalidMoveOrCommand;
            }
        }

        public static string MissingBalloonPop
        {
            get
            {
                return missingBalloonPop;
            }
        }

        public static string GoodBye
        {
            get
            {
                return goodbye;
            }
        }

        public static string EnterInput
        {
            get
            {
                return enterInput;
            }
        }
    }
}
