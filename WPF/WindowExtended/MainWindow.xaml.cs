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

namespace WindowExtended
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState=WindowState.Minimized;
        }


        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }


        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else
                {
                    Application.Current.MainWindow.DragMove();
                }
        }
        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                //MaximizeButton.Content = "1";
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                //MaximizeButton.Content = "2";
            }

        }
        bool isTreeFill;

        //commands
        public readonly static RoutedUICommand GenerateTree;
        public readonly static RoutedUICommand ClearTree;
        static MainWindow()
        {
            GenerateTree = new RoutedUICommand("Generate Tree", "GenerateTree", typeof(MainWindow));
            ClearTree = new RoutedUICommand("Clear Tree", "ClearTree", typeof(MainWindow));
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            StringBuilder s = new StringBuilder();
            s.Append(logicalTree.GetType().Name);

            var f = System.Windows.LogicalTreeHelper.GetParent(logicalTree);
            while (f != null)
            {
                s.Append("->" + f.GetType().Name);
                f = System.Windows.LogicalTreeHelper.GetParent(f);
            }
            logicalTree.Content = s.ToString();
            s.Clear();
            s.Append(logicalTree.GetType().Name);

            f = System.Windows.Media.VisualTreeHelper.GetParent(visualTree);
            while (f != null)
            {
                s.Append("->" + f.GetType().Name);
                f = System.Windows.Media.VisualTreeHelper.GetParent(f);
            }
            visualTree.Content = s.ToString();
            isTreeFill = true;

        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            visualTree.Content = "";
            logicalTree.Content = "";
            isTreeFill = false;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isTreeFill;
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isTreeFill;
        }
    }
}
