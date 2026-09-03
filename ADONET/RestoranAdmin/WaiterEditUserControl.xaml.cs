using ADONETDemoFramework.Models;
using Microsoft.EntityFrameworkCore;
using RestoranAdmin.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RestoranAdmin
{
    /// <summary>
    /// Interaction logic for WaiterEditUserControl.xaml
    /// </summary>
    public partial class WaiterEditUserControl : UserControl
    {
        public WaiterEditUserControl()
        {
            InitializeComponent();
        }

        public void Show()
        {
            using (var context = new RestoranDbContext())
            {

                
                var items = context.Waiters.Include("ClientTableWaiters").ToList();
                dg.ItemsSource = new ObservableCollection<Waiter>(items);
            }
            //Visibility = Visibility.Visible;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var collection = dg.ItemsSource as ObservableCollection<Waiter>;
            using (var context = new RestoranDbContext())
            {
                context.Waiters.UpdateRange(collection.ToList());
                context.SaveChanges();
            }
        }

    }
}
