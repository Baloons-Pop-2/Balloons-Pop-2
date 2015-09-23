namespace BalloonsPop.Traversals
{
    public interface ITraversalEffect
    {
        void Pop(int row, int col, IBoard board);
    }
}
