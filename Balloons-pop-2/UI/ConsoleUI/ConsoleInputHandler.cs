using System;
using BalloonsPops.UI.InputHandler;

namespace BalloonsPops.UI.ConsoleUI
{
    public class ConsoleInputHandler : IInputHandler
    {
        public string Read()
        {
            var input = Console.ReadLine();
            return input;
        }

        public bool VerifyInput(string input)
        {
            throw new NotImplementedException();
        }
    }
}
