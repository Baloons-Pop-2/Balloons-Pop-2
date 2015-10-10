using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalloonsPop;
using BalloonsPopConsoleApp.Commands;
using BalloonsPopConsoleApp.Logs;
using BalloonsPopConsoleApp.Memory;
using BalloonsPopConsoleApp.Miscellaneous;
using BalloonsPopConsoleApp.Models;
using Moq;
using NUnit.Framework;

namespace BalloonsPopConsoleApp.Tests.Commands
{
    [TestFixture]
    public class ShowTopScoreCommandTests
    {
        private object[] sourceLists = { 
                new List<Tuple<string, int>>
                {
                    new Tuple<string, int>("aaaa", 1675), 
                    new Tuple<string, int>("dasd123", 3450), 
                    new Tuple<string, int>("pesho", 4500),
                    new Tuple<string, int>("meesho", 2100),
                    new Tuple<string, int>("4 2 4", 2800),
                    new Tuple<string, int>("anonymous", 7280)
                },
                new List<Tuple<string, int>>
                {
                    new Tuple<string, int>("anonymous", 0), 
                    new Tuple<string, int>("pepoooouu", 7450)
                },
                new List<Tuple<string, int>>
                {
                    new Tuple<string, int>("peeeeeeeeeeeeeshooooooooo weeeeeheeee", 17750),
                    new Tuple<string, int>("anonymous", 7280)
                }
        };
        
        [Test]
        public void OnExecuteShouldDisplayNoScoresMessageWhenThereAreNoEntries()
        {
            var mockHsP = new Mock<IHighscoreProcessor>();
            mockHsP.Setup(x => x.GetTopHighscores())
                .Callback(() => { })
                .Returns(new List<Tuple<string, int>> { });

            var ctx = new CommandContext(new Logger(), new Board(5, 5, new RandomGenerator()), 2, 2, new BoardMemory(), Highscore.GetInstance(),
                mockHsP.Object);

            var cmd = new ShowTopScoreCommand();

            cmd.Execute(ctx);

            var expected = ctx.Messages["noscores"];

            Assert.AreEqual(expected, ctx.CurrentMessage);
        }

        [Test]
        public void OnExecuteShouldDisplayValidSortedFormattedScoresWhenThereAreEntries(
            [ValueSource("sourceLists")] List<Tuple<string, int>> scores)
        {
            var mockHsP = new Mock<IHighscoreProcessor>();
            mockHsP.Setup(x => x.GetTopHighscores())
                .Callback(() => { })
                .Returns(scores);

            var ctx = new CommandContext(new Logger(), new Board(5, 5, new RandomGenerator()), 2, 2, new BoardMemory(), Highscore.GetInstance(),
                mockHsP.Object);

            var cmd = new ShowTopScoreCommand();

            cmd.Execute(ctx);

            var header = new string('-', 15) + " Top 5 players: " + new string('-', 15) + Environment.NewLine;
            var footer = Environment.NewLine + new string('-', 2) + " " + new string('-', 40) + " " + new string('-', 2) + Environment.NewLine;
            var sb = new StringBuilder();

            sb.Append(header);
            sb.Append(string.Join(
                Environment.NewLine,
                scores.Select(x =>
                {
                    if (x.Item1.Length > 18)
                    {
                        return new Tuple<string, int>(x.Item1.Substring(0, 15) + "...", x.Item2);
                    }

                    return x;
                }).Select(x => string.Format("{0,-20} {1}", x.Item1, x.Item2))));
            sb.Append(footer);

            var expected = sb.ToString();

            Assert.AreEqual(expected, ctx.CurrentMessage);
        }
    }
}
