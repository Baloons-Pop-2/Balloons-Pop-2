using System;
using System.Collections.Generic;
using System.Linq;
using BalloonsPop.UI.InputHandler;

namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    public class ConsoleInputHandler : IInputHandler
    {
        protected static readonly IList<string> ValidCommands = new List<string>()
        {
            "exit",
            "restart",
            "top",
            "undo"
        };

        public string Read()
        {
            var input = Console.ReadLine().Trim();

            if (String.IsNullOrWhiteSpace(input))
            {
                return "invalidInput";
            }
            else
            {
                return input;
            }
        }

        public string ParseInput(string input)
        {
            var inputWords = input.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (inputWords.Length != 1 && !IsValidPopInput(input))
            {
                return "invalidInput";
            }

            if (inputWords.Length == 1 && ValidCommands.Contains(inputWords[0]))
            {
                return inputWords[0];
            }
            else if (IsValidPopInput(input))
            {
                return String.Format("pop {0} {1}", inputWords[0], inputWords[1]);        
            }
            return "invalidInput";
        }

        private static bool IsValidPopInput(string input)
        {
            var splitInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (splitInput.Length == 2)
            {
                return (splitInput[0] + splitInput[1]).All(Char.IsDigit);
            }

            return false;
        }
    }
}
