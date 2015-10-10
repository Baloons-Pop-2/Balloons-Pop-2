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

    /// <summary>
    /// The class is responsible for saving and reading highscore from xml files.
    /// </summary>
    public class HighscoreProcessor : IHighscoreProcessor
    {
        private const string Path = @"..\..\..\score.xml";

        /// <summary>
        /// Saves highscore to an existing file, otherwise one is created and highscore is written.
        /// </summary>
        /// <param name="highscore">the score object</param>
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

        /// <summary>
        /// Retrieves all highscores from a file.
        /// </summary>
        /// <returns>IEnumerable of Tuple&lt;string, int&gt;, otherwise - empty list</returns>
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
