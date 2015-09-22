using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop
{
    public interface IMemorizeable<T>
    {
        T SaveMemento();
        void RestoreMemento(T memento);
    }
}
