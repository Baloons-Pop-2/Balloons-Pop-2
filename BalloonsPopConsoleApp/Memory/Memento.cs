namespace BalloonsPopConsoleApp.Memory
{
    using BalloonsPop;

    public class Memento : IBoardMemento
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
    }
}
