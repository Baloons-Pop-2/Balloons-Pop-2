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
        const Balloon EmptyCell = null;
        const int HighscoresMaxCount = 4;

        private static int initialBalloonsCount = Rows * Cols;
        private static int userMoves = 0;
        private static int poppedBalloons = 0;
        
        private static Board board = new Board(Rows, Cols);
        private static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();
        private static BalloonPopper bp = new BalloonPopper(board);

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
            int activeCell;
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

            if (IsLegalMove(row, col))
            {
                bp.Pop(row, col);
                //activeCell = board[row, col].Value;
                //RemoveAllBaloons(row, col, activeCell);
                userMoves++;
            }
            else
            {
                ManageInvalidMove();
            }

            //ClearEmptyCells();
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
                else
                {
                    position++;
                    Console.WriteLine("{0}. {1} --> {2} moves", position, stat.Value, stat.Key);
                }
            }
        }

        private static void RemoveAllBaloons(int row, int col, int currentCell)
        {
            if (IsInRange(row, col) &&
                board[row, col] != EmptyCell &&
                board[row, col].Value == currentCell)
            {
                board[row, col] = EmptyCell;
                poppedBalloons++;

                RemoveAllBaloons(row - 1, col, currentCell); // Up
                RemoveAllBaloons(row + 1, col, currentCell); // Down 
                RemoveAllBaloons(row, col + 1, currentCell); // Left
                RemoveAllBaloons(row, col - 1, currentCell); // Right
            }
            else
            {
                initialBalloonsCount -= poppedBalloons;
                poppedBalloons = 0;
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