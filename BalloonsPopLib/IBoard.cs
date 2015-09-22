namespace BalloonsPop
{
    public interface IBoard : IMemorizeable<IBoardMemento>
    {
        int Rows { get; }
        int Cols { get; }
        IBalloon this[int row, int col] { get; set; }
        void Reset();
        bool IsValidPop(int row, int col);
    }
}
