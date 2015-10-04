namespace BalloonsPopConsoleApp
{
    using BalloonsPop;

    public class BoardMemory : IBoardMemory
    {
        public IBoardMemento Memento { get; set; }
    }
}
