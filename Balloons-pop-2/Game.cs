using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BalloonsPops
{
    public class Game
    {
        const int Rows = 5;
        const int Cols = 10;
        const string WelcomeMessage = "Welcome to \"Balloons Pops\" game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        const Balloon EmptyCell = null;
        const int HighscoresMaxCount = 4;
        const string ExitCommand = "exit";
        const string RestartCommand = "restart";
        const string TopCommand = "top";

        private static int initialBalloonsCount = Rows * Cols;
        private static int userMoves = 0;
        private static int poppedBalloons = 0;

        private static Balloon[,] board = new Balloon[Rows, Cols];
        private static StringBuilder userInput = new StringBuilder();
        private static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();

        public static void Start()
        {
            Console.WriteLine(WelcomeMessage);
            initialBalloonsCount = Rows * Cols;
            userMoves = 0;

            poppedBalloons = 0;
            CreateBoard();
            PrintTable();
            while (true)
            {
                GameLogic(userInput);
            }
        }

        public static void CreateBoard()
        {
            int randomValue = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    randomValue = int.Parse(RandomGenerator.GetRandomInt());
                    board[row, col] = new Balloon(randomValue);
                }
            }
        }

        public static void PrintTable()
        {
            StringBuilder output = new StringBuilder();
            string leftPadding = new String(' ', 4);

            output.Append(leftPadding);
            for (int col = 0; col < Cols; col++)
            {
                output.Append(col + " ");
            }

            output.AppendLine();
            string separator = leftPadding + new string('-', 21);
            output.AppendLine(separator);

            for (int row = 0; row < Rows; row++)
            {
                output.Append(row + " | ");

                for (int col = 0; col < Cols; col++)
                {
                    if (board[row, col] == null)
                    {
                        output.Append(". ");
                        continue;
                    }
                    output.Append(board[row, col].Value + " ");
                }
                output.AppendLine("| ");
            }

            output.AppendLine(separator);

            Console.WriteLine(output);
        }

        public static void GameLogic(StringBuilder userInput)
        {
            PlayGame();
            userMoves++;
            userInput.Clear();
        }

        private static bool IsInRange(int row, int col)
        {
            bool rowIsInRange = row >= 0 && row < Rows;
            bool colIsInRange = col >= 0 && col < Cols;

            return rowIsInRange && colIsInRange;
        }

        private static bool IsLegalMove(int row, int col)
        {
            if (!IsInRange(row, col))
            {
                return false;
            }
            else
            {
                return board[row, col] != EmptyCell;
            }
        }

        private static void InvalidInput()
        {
            Console.WriteLine("Invalid move or command");
            userInput.Clear();
            GameLogic(userInput);
        }

        private static void InvalidMove()
        {
            Console.WriteLine("Illegal move: cannot pop missing ballon!");
            userInput.Clear();
            GameLogic(userInput);
        }

        private static void ShowStatistics()
        {
            PrintTheScoreBoard();
        }

        private static void Exit()
        {
            Console.WriteLine("Good Bye");
            Thread.Sleep(1000);
            Console.WriteLine(userMoves.ToString());
            Console.WriteLine(initialBalloonsCount.ToString());
            Environment.Exit(0);
        }

        private static void Restart()
        {
            Start();
        }

        private static void ReadTheIput()
        {
            if (!IsFinished())
            {
                Console.Write("Enter a row and column: ");
                userInput.Append(Console.ReadLine());
            }
            else
            {
                Console.Write(" You popped all baloons in " + userMoves + " moves."
                                 + "Please enter your name for the top scoreboard:");
                userInput.Append(Console.ReadLine());
                statistics.Add(userMoves, userInput.ToString());
                PrintTheScoreBoard();
                userInput.Clear();
                Start();
            }
        }

        private static void PrintTheScoreBoard()
        {
            int position = 0;

            Console.WriteLine("Scoreboard:");
            foreach (KeyValuePair<int, string> stat in statistics)
            {
                if (position == HighscoresMaxCount)
                {
                    break;
                }
                else
                {
                    position++;
                    Console.WriteLine("{0}. {1} --> {2} moves", position, stat.Value, stat.Key);
                }
            }
        }

        private static void ProcessInput()
        {
            ReadTheIput();
            string inputCommand = userInput.ToString();

            if (userInput.ToString() == string.Empty)
            {
                InvalidInput();
            }
            else if (userInput.ToString() == TopCommand)
            {
                ShowStatistics();
                userInput.Clear();
                ProcessInput();
            }
            else if (userInput.ToString() == RestartCommand)
            {
                userInput.Clear();
                Restart();
            }
            else if (userInput.ToString() == ExitCommand)
            {
                Exit();
            }
        }

        private static void PlayGame()
        {
            ProcessInput();

            int activeCell;
            int row = -1;
            int col = -1;
            int[] rowAndCol = userInput.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            try
            {
                row = rowAndCol[0];
                col = rowAndCol[1];
            }
            catch (Exception)
            {
                InvalidInput();
            }

            if (IsLegalMove(row, col))
            {
                activeCell = board[row, col].Value;
                RemoveAllBaloons(row, col, activeCell);
            }
            else
            {
                InvalidMove();
            }

            ClearEmptyCells();
            PrintTable();
        }

        private static void RemoveAllBaloons(int row, int col, int currentCell)
        {
            if (
                IsInRange(row, col) &&
                (board[row, col] != null) &&
                (board[row, col].Value == currentCell)
            )
            {
                board[row, col] = EmptyCell;
                poppedBalloons++;
                // Up
                RemoveAllBaloons(row - 1, col, currentCell);
                // Down 
                RemoveAllBaloons(row + 1, col, currentCell);
                // Left
                RemoveAllBaloons(row, col + 1, currentCell);
                // Right
                RemoveAllBaloons(row, col - 1, currentCell);
            }
            else
            {
                initialBalloonsCount -= poppedBalloons;
                poppedBalloons = 0;
                return;
            }
        }

        private static void ClearEmptyCells()
        {
            int row;
            int col;

            Queue<Balloon> baloonsToPop = new Queue<Balloon>();
            for (col = Cols - 1; col >= 0; col--)
            {
                for (row = Rows - 1; row >= 0; row--)
                {
                    if (board[row, col] != EmptyCell)
                    {
                        baloonsToPop.Enqueue(board[row, col]);
                        board[row, col] = EmptyCell;
                    }
                }

                row = Rows - 1;
                while (baloonsToPop.Count > 0)
                {
                    board[row, col] = baloonsToPop.Dequeue();
                    row--;
                }

                baloonsToPop.Clear();
            }
        }

        private static bool IsFinished()
        {
            return initialBalloonsCount == 0;
        }
    }
}
