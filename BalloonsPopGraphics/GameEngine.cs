using BalloonsPop;
using BalloonsPopConsoleApp;
using BalloonsPopConsoleApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BalloonsPopGraphics
{
    class GameEngine : IGameEngine
    {
        const int size = 8;
        private GraphicsBoard board;
        private ContentControl window;

        public GameEngine(ContentControl window)
        {
            this.board = new GraphicsBoard(size, size);
            this.window = window;
        }

        public void Run()
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.ShowGridLines = true;

            for (int rowAndCol = 0; rowAndCol < size; rowAndCol++)
            {
                DynamicGrid.RowDefinitions.Add(new RowDefinition());
                DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {

                    var image = this.board[row, col];
                    image.Tag = row + " " + col;
                    image.MouseDown += ButtonOKClicked;
                    DynamicGrid.Children.Add(image);

                    Grid.SetRow(image, row);
                    Grid.SetColumn(image, col);
                }
            }

            this.window.Content = DynamicGrid;
        }

        private void ButtonOKClicked(object sender, RoutedEventArgs e)
        {
            var el = sender as Image;
            var place = el.Tag.ToString().Split(' ').ToArray();
            MessageBox.Show(place[0] + " " + place[1]);
        }
    }
}
