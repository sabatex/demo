using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfAppADONETDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestoranDS restoranDS;
        private RestoranDSTableAdapters.WaitersTableAdapter waitersTableAdapter;
        private System.Windows.Data.CollectionViewSource waitersViewSource;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            restoranDS = new RestoranDS();
            // Load data into the table Product. You can modify this code as needed.
            waitersTableAdapter = new RestoranDSTableAdapters.WaitersTableAdapter();
            waitersTableAdapter.Fill(restoranDS.Waiters);

            dg.ItemsSource = restoranDS.Waiters.DefaultView;

        }
    }
}
