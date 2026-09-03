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

namespace TemplateTree
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder s = new StringBuilder();
            s.Append(logicalTree.GetType().Name);

            var f = System.Windows.LogicalTreeHelper.GetParent(logicalTree);
            while (f!=null)
            {
               s.Append("->"+f.GetType().Name); 
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

        }



    }
}
