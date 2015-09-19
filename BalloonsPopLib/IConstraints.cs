namespace BalloonsPop
{
    public interface IConstraints
    {
        int BalloonMinValue { get; }
        int BalloonMaxValue { get; }
        int BoardRows { get; }
        int BoardColumns { get; }
    }
}
