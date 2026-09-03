using Chess;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Desk _desk = new Desk();

        SFigurePosition? selectedFigure = null;
        SFigurePosition[] enabledCoords = new SFigurePosition[0];
        public MainWindow()
        {
            InitializeComponent();
        }

        FigureCell GetFigure(int x,int y)
        {
            foreach (UIElement ui in deskGrid.Children)
            {
                int rowIndex = System.Windows.Controls.Grid.GetRow(ui);
                int columnIndex = System.Windows.Controls.Grid.GetColumn(ui);
                if (rowIndex == y && columnIndex == x)
                    return (FigureCell)ui;
            }
            return null;
        }

        SFigurePosition GetFigureCoordinates(FigureCell figure)
        {
            int x = System.Windows.Controls.Grid.GetColumn(figure);
            int y = System.Windows.Controls.Grid.GetRow(figure);
            return new SFigurePosition(y-1,x-1);
        }

        SFigurePosition GetCoordiantes(int i, int j)
        {
            if (_desk.ActivePlayerColor == FigureColor.White)
            {
                return new SFigurePosition(i, j);
            }
            return new SFigurePosition(7 - i, 7 - j);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _desk.ClearDesk();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var coords = GetCoordiantes(i, j);
                    var control = GetFigure(j + 1, i + 1);
                    if (control != null)
                    {
                        control.CurrentFigure = _desk[coords.X, coords.Y];
                        control.MouseEnter += Cell_MouseEnter;
                        control.MouseLeave += Cell_MouseLeave;
                        control.MouseDown += Cell_MouseDown;
                    }
                }
            }
        }



        private void Cell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var f = sender as FigureCell;
            if (f == null) return;
            var cords = GetFigureCoordinates(f);
            if (selectedFigure != null)
            {


            }
            else
            {
                if (f.CurrentFigure != null)
                {
                    enabledCoords = _desk.GetMoveCords(cords);
                    if (enabledCoords.Length > 0)
                    {
                        selectedFigure = cords;
                        f.IsMarkFigure = true;
                        foreach (var c in enabledCoords)
                            GetFigure(c.Y + 1, c.X + 1).IsMarkFigure = true;

                    }
                }
            }
        }

        private void Cell_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Cell_MouseEnter(object sender, MouseEventArgs e)
        {
            FigureCell f = sender as FigureCell;
            if (f != null)
            {
                if (f.CurrentFigure != null)
                {
                    if (_desk.CanMove(GetFigureCoordinates(f)))  
                        this.Cursor = Cursors.Hand;

                }

            }
            
        }
    }
}
