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

namespace WPFResorceDemo
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

        static Uri blackUri = new Uri("BlackThemeDictionary.xaml", UriKind.Relative);
        static Uri whiteUri = new Uri("WhiteThemeDictionary.xaml", UriKind.Relative);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = App.Current.Resources.MergedDictionaries.SingleOrDefault(s=>s.Source==whiteUri);
            if (a != null)
            {
                a.Source = blackUri;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var a = App.Current.Resources.MergedDictionaries.SingleOrDefault(s => s.Source == blackUri);
            if (a != null)
            {
                a.Source = whiteUri;
            }

        }
    }
}
