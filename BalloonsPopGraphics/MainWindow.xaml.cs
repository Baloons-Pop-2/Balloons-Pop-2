using BalloonsPopConsoleApp;
using BalloonsPopConsoleApp.Engine;
using BalloonsPopConsoleApp.Factories;
using BalloonsPopConsoleApp.Logs;
using BalloonsPopConsoleApp.UI.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BalloonsPopGraphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int boardSize = 8;
        private test[,] field = new test[8, 8];
        public MainWindow()
        {
            Grid grid = new Grid();

            for (int i = 0; i < boardSize; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }


            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    field[row, col] = new test(new Effect(), ((row*col) % 5 + 1));
                    field[row, col].Source = new BitmapImage(new Uri(@"\Images\" + field[row,col].Value + ".png", UriKind.Relative));
                    field[row, col].Tag = row + "/" + col;
                    field[row, col].MouseDown += Click;

                    Grid.SetRow(field[row, col], row);
                    Grid.SetColumn(field[row, col], col);

                    grid.Children.Add(field[row, col]);
                }
            }

            this.Content = grid;

            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            var s = sender as test;
            var pos = s.Tag.ToString().Split('/').Select(x=>int.Parse(x)).ToArray();
            var ef = field[pos[0], pos[1]].Effect;
            ef.Pop(pos[0], pos[1], field);
            //s.Pop();
        }
    }
}
