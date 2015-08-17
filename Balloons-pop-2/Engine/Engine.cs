using System;
using BalloonsPops.UI;

namespace BalloonsPops.Engine
{
    public class GameEngine
    {
        public GameEngine(IUserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public IUserInterface UserInterface { get; private set; }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void HandleCommands()
        {
            throw new NotImplementedException();
        }

        public void ExecuteTurn()
        {
            throw new NotImplementedException();
        }
    }
}