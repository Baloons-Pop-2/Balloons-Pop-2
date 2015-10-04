namespace BalloonsPopConsoleApp.Memory
{
    using BalloonsPop;

    public class BoardMemory : IBoardMemory
    {
        public IBoardMemento Memento { get; set; }
    }
}
