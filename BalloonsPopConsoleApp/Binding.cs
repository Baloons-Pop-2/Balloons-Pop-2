using BalloonsPop;
using BalloonsPop.Commands;
using BalloonsPopConsoleApp.Commands;
using BalloonsPopConsoleApp.Factories;
using Ninject.Modules;

namespace BalloonsPopConsoleApp
{
    public class Binding : NinjectModule
    {
        public override void Load()
        {
            Bind<IBalloon>().To<Balloon>();
            Bind<IBoard>().To<Board>();
            Bind<ICommandContext>().To<CommandContext>();
            Bind<IEffectFactory>().To<EffectFactory>();
            Bind<IBalloonFactory>().To<BalloonFactory>();

            Bind<ICommand>().To<PopBalloonCommand>();
            Bind<ICommand>().To<ExitCommand>();
            Bind<ICommand>().To<RestartCommand>();
            Bind<ICommand>().To<ShowTopScoreCommand>();

        }
    }
}
