// <copyright  file="HighscoreProcessor.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using BalloonsPop;

    public class HighscoreProcessor : IHighscoreProcessor
    {
        private const string Path = @"..\..\..\score.xml";

        public void SaveHighscore(IHighscore highscore)
        {
            const string RootElementString = "highscores";

            XDocument score;

            if (File.Exists(Path))
            {
                score = XDocument.Load(Path);
            }
            else
            {
                score = new XDocument(new XElement(RootElementString));
            }

            var root = score.Root;

            root.Add(new XElement("score", new XElement("username", highscore.Username), new XElement("points", highscore.CurrentScore)));

            score.Save(Path);
        }

        public IEnumerable<Tuple<string, int>> GetTopHighscores()
        {
            var topHighscores = new List<Tuple<string, int>>();

            try
            {
                var doc = XDocument.Load(Path);

                topHighscores = doc.Descendants("score")
                    .Select(x => new Tuple<string, int>(x.Element("username").Value, int.Parse(x.Element("points").Value)))
                    .OrderByDescending(x => x.Item2)
                    .Take(5)
                    .ToList();

            }
            catch (FileNotFoundException)
            {
            }

            return topHighscores;
        }
    }
}
