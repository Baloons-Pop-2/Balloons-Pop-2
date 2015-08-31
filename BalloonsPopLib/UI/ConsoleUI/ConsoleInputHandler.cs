using System;
using BalloonsPop.UI.InputHandler;

namespace BalloonsPop.UI.ConsoleUI
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
