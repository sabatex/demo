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
using System.Windows.Threading;

namespace WpfApp1
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
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
        private static Action EmptyDelegate = delegate () { };
        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
