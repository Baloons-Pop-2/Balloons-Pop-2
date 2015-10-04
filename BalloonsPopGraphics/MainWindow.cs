using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BalloonsPopGraphics
{
    public partial class MainWindow
    {
        const int boardSize = 8;
        private GraphicsBalloon[,] field = new GraphicsBalloon[boardSize, boardSize];
        private ImageSourceFactory imageSourceProvider;
        private GraphicsBalloonFactory balloonFactory;

        public void InitBoard()
        {
            this.imageSourceProvider = new ImageSourceFactory();
            this.balloonFactory = new GraphicsBalloonFactory(this.imageSourceProvider);

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
                    field[row, col] = this.balloonFactory.GetBalloon(RandomGenerator.GetRandomInt());

                    field[row, col].Source = field[row, col].ImageSource;
                    field[row, col].Tag = row + "/" + col;
                    field[row, col].MouseDown += Click;

                    Grid.SetRow(field[row, col], row);
                    Grid.SetColumn(field[row, col], col);

                    grid.Children.Add(field[row, col]);
                }
            }

            this.Content = grid;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            var s = sender as GraphicsBalloon;
            var pos = s.Tag.ToString().Split('/').Select(x => int.Parse(x)).ToArray();
            var ef = field[pos[0], pos[1]].TraversalEffect;
            ef.Pop(pos[0], pos[1], this.field);
        }
    }
}
