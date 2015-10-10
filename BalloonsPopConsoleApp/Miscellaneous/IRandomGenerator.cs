using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopConsoleApp.Miscellaneous
{
    public interface IRandomGenerator
    {
        int GetInt(int min, int max);
    }
}
