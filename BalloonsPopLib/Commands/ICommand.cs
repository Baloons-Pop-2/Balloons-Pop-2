namespace BalloonsPop.Commands
{
    public interface ICommand
    {
        void Execute(CommandContext ctx);
    }
}
