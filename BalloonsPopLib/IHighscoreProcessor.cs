using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop
{
    public interface IHighscoreProcessor
    {
        void SaveHighscore(IHighscore highscore);

        IEnumerable<Tuple<string, int>> GetTopHighscores();
    }
}
