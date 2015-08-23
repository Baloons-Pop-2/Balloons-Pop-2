using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BalloonsPops
{
    public class Game
    {
        const int Rows = 5;
        const int Cols = 10;
        const int HighscoresMaxCount = 4;

        private static int initialBalloonsCount = Rows * Cols;
        private static int userMoves = 0;
        private static int poppedBalloons = 0;
        
        private static Board board = new Board(Rows, Cols);
        private static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();
        private static BalloonPopManager popManager = new BalloonPopManager(board);

        public void Start()
        {
            Console.WriteLine(MessageStrings.Welcome);
            initialBalloonsCount = Rows * Cols;
            userMoves = 0;

            poppedBalloons = 0;

            Console.WriteLine(board);

            while (true)
            {
                MakeMove();
            }
        }
        
        public void MakeMove()
        {
            Console.Write(MessageStrings.EnterInput);
            string input = Console.ReadLine().Trim();
            ParseAndDispatchInput(input);
            
            Update();
        }

        private void PopBalloon(string input)
        {
            int row = -1;
            int col = -1;
            int[] rowAndCol = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            try
            {
                row = rowAndCol[0];
                col = rowAndCol[1];
            }
            catch (Exception)
            {
                ManageInvalidInput();
            }

            if (board.IsValidPop(row, col))
            {
                popManager.Pop(row, col);
                userMoves++;
            }
            else
            {
                ManageInvalidMove();
            }
        }

        private void Update()
        {
            Console.Clear();
            Console.WriteLine(board);
        }

        private void ParseAndDispatchInput(string input)
        {
            switch (input)
            {
                case CommandStrings.Top:
                    ShowStatistics();
                    break;
                case CommandStrings.Restart:
                    board.Reset();
                    Restart();
                    Update();
                    break;
                case CommandStrings.Exit:
                    Exit();
                    break;
                default:
                    PopBalloon(input);
                    break;
            }
        }

        private void ManageInvalidInput()
        {
            Console.WriteLine(MessageStrings.InvalidMoveOrCommand);
            MakeMove();
        }

        private void ManageInvalidMove()
        {
            Console.WriteLine(MessageStrings.MissingBalloonPop);
            MakeMove();
        }

        private void ShowStatistics()
        {
            PrintTheScoreBoard();
        }

        private void Exit()
        {
            Console.WriteLine(MessageStrings.GoodBye);
            Thread.Sleep(1000);
            Console.WriteLine(userMoves.ToString());
            Console.WriteLine(initialBalloonsCount.ToString());
            Environment.Exit(0);
        }

        private void Restart()
        {
            userMoves = 0;
            poppedBalloons = 0;
        }

        private static void PrintTheScoreBoard()
        {
            int position = 0;

            Console.WriteLine("Scoreboard: ");
            foreach (KeyValuePair<int, string> stat in statistics)
            {
                if (position == HighscoresMaxCount)
                {
                    break;
                }

                position++;
                Console.WriteLine("{0}. {1} --> {2} moves", position, stat.Value, stat.Key);
            }
        }

        private static bool IsFinished()
        {
            return board.UnpoppedBalloonsCount == 0;
        }
    }
}
