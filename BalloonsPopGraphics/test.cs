using BalloonsPop.Traversals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BalloonsPopGraphics
{
    public class test : Image
    {
        public test(Effect ef, int value) : base() { this.Effect = ef; this.Value = value; this.IsPopped = false; }
        public Effect Effect { get; set; }
        public int Value { get; set; }

        public bool IsPopped { get; set; }

        public void Pop()
        {
            this.IsPopped = true;
            this.Source = new BitmapImage(new Uri(@"\Images\0.png", UriKind.Relative));
        }

        public void Unpop()
        {
            this.IsPopped = false;
            this.Source = new BitmapImage(new Uri(@"\Images\" + this.Value + ".png", UriKind.Relative));
        }
    }
}
