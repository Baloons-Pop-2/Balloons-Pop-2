using System;
using System.Text;
using BalloonsPop.UI.InputHandler;

namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    public class ConsoleInputHandler : IInputHandler
    {
        public string Read()
        {
            var input = Console.ReadLine();

            if (!IsValidInput(input))
            {
                return string.Empty;
            }
            else
            {
                return input;
            }
        }


        // TODO: FIX dem bad codez!!!!!!!!!!
        public string ParseInput(string input)
        {
            var inputWords = input.Split(' ');
            var validCommands = new string[]
            {
                "exit",
                "restart",
                "top",
                "undo"
            };
            int pesho;
            var sb = new StringBuilder();

            if (inputWords.Length == 1)
            {
                if (Array.IndexOf(validCommands, inputWords[0]) >= 0)
                {
                    return inputWords[0];
                }
                else
                {
                    return "";
                }
            }
            else if (int.TryParse(inputWords[0][0].ToString(), out pesho) &&
                int.TryParse(inputWords[1][0].ToString(), out pesho))
            {
                var row = inputWords[0][0];
                var col = inputWords[1][0];

                sb.Append("pop");
                sb.Append(" ");
                sb.Append(row + " " + col);

                return sb.ToString();
            }

            return "";
        }

        private bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
