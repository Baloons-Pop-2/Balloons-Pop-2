using BalloonsPop;

namespace BalloonsPopConsoleApp
{
    class Memento : IBoardMemento
    {
        private IBalloon[,] board;

        public Memento(IBalloon[,] board)
        {
            this.Board = board;
            this.Rows = board.GetLength(0);
            this.Cols = board.GetLength(1);
        }

        public int Rows { get; set; }

        public int Cols { get; set; }

        public IBalloon[,] Board
        {
            get
            {
                return (IBalloon[,])this.board.Clone();
            }

            private set
            {
                this.board = value;
            }
        }

        public IBalloon this[int row, int col]
        {
            get
            {
                return this.board[row, col];
            }
            set { }
        }

        public void Reset()
        {
            return;
        }

        public bool IsValidPop(int row, int col)
        {
            return true;
        }

        public IBoardMemento SaveMemento()
        {
            return default(IBoardMemento);
        }


        public void RestoreMemento(IBoardMemento memento)
        {
            return;
        }
    }
}
