using Microsoft.EntityFrameworkCore;
using RestoranClient.Data;
using RestoranClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RestoranClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Login login { get; set; }

        public ObservableCollection<MainWindowViewModel> Orders { get; set; }
        public Abonent[] Abonents { get; set; }
        //public SourceItem[] SourceItems { get; set; }
        public FoodItem[] FoodItems { get; set; }

        public ObservableCollection<Detail> Details { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Details = new ObservableCollection<Detail>();
            //model = new MainWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = "Клієнт офіціанта";
            login = new Login();
            mainGrid.Children.Add(login);
            login.HorizontalAlignment = HorizontalAlignment.Center;
            login.Width = 400;
            login.VerticalAlignment = VerticalAlignment.Center;
            login.BorderBrush = Brushes.Black;
            login.Background = Brushes.AliceBlue;
            login.LoginResult += Login_LoginResult;
            



            //var frm = new Login();
            //var result = frm.ShowDialog();
            //if (result == false || result == null)
            //{
            //    this.Close();
            //    return;
            //}

            //Title = $"Офіціант {Config.WaiterName} : {DateTime.Now}";
            //DataContext = model;
            //using (var context = new RestoranDbContext())
            //{
            //    var r = context.Order.Where(w => w.waiter_id == Config.WaiterId)
            //        .Join(context.Abonent, ws => ws.abonent_id, ab => ab.id, (ws, ab) => new MainWindowViewModel { id = ws.id, time_order = ws.time_order.ToString("H:mm:ss"), abonent = ab.name,Bill=ws.bill }).ToArray();

            //    Orders = new ObservableCollection<MainWindowViewModel>(r);
            //    Abonents = context.Abonent.ToArray();
            //    SourceItems = context.Sources.ToArray();
            //    FoodItems = context.Items.ToArray();

            //}
            //dg.ItemsSource = Orders;




        }

        private void RefreshGrid()
        {
            using (var context = new RestoranDbContext())
            {
                var r = context.Order.Where(w => w.WaiterId == Config.WaiterId)
                    .Join(context.Abonent, ws => ws.AbonentId, ab => ab.Id, (ws, ab) => new MainWindowViewModel { id = ws.Id, time_order = ws.TimeOrder.ToString("H:mm:ss"), abonent = ab.Name, Bill = ws.Bill }).ToArray();
                 dg.ItemsSource = new ObservableCollection<MainWindowViewModel>(r);
                //var items = context.Order.ToArray();
                //var s = new StringBuilder();
                //foreach (var v in items)
                //{
                //    var str = "new Order { Id ="
                //        + $" {v.Id}, WaiterId = {v.WaiterId}, AbonentId = {v.AbonentId}, TimeOrder";

                //    s.AppendLine("new FoodItem { Name ="+$" \"{v.Name}\",Price = {v.Price}M, Id = {v.Id}"+" },");
                //}
                //var st = s.ToString();
                //File.WriteAllText("sql.txt", st);
                


            }
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {

        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            //cbAbonent.ItemsSource = Abonents;
            //cbAbonent.DisplayMemberPath = "name";
            //cbAbonent.SelectedValuePath = "id";
            //cbAbonent.SelectedValue = Abonents[0]?.id;
            //cbSource.ItemsSource = SourceItems;
            //cbSource.DisplayMemberPath = "name";
            //cbSource.SelectedValuePath = "id";
            //cbSource.SelectedValue = SourceItems[0]?.id;
            //dpStart.Text = DateTime.Now.ToString("H.mm.ss");
            ////grid
            //cbitem.ItemsSource = FoodItems;
            //cbitem.DisplayMemberPath = "name";
            //cbitem.SelectedValuePath = "id";
            //Details.Clear();
            //dgOrder.ItemsSource = Details;


            mainForm.Visibility = Visibility.Collapsed;
            
            orderEdit.ShowOrderEdit(mainForm);
        }


        private void orderEdit_OnCancelOrder()
        {
            mainForm.Visibility = Visibility.Visible;
            orderEdit.Visibility = Visibility.Collapsed;
        }

        private void orderEdit_OnSaveOrder(Order obj)
        {
            using (var context = new RestoranDbContext())
            {
                //context.Order.Add(obj);
                //
                //obj.Details.Clear();
                context.Order.Update(obj);
                //context.SaveChanges();

                //obj.Details.Add(new Detail() { ItemsId = 1,Price = 10,Count = 2,Bill=20
                //});
                //context.Order.Add(obj);
                context.SaveChanges();
            }
            RefreshGrid();
            mainForm.Visibility = Visibility.Visible;
            orderEdit.Visibility = Visibility.Collapsed;
        }

        private void Login_LoginResult(int? arg1, string arg2)
        {
            if (arg1 == null)
                Close();
            else
            {
                Config.WaiterId = arg1.Value;
                Config.WaiterName = arg2;
                Title = $"Офіціант {Config.WaiterName} : {DateTime.Now}";
                //login.Visibility = Visibility.Hidden;
                mainGrid.Children.Remove(login);
                login.LoginResult -= Login_LoginResult;
                login = null;
                RefreshGrid();
                mainForm.Visibility = Visibility.Visible;
            }
        }

        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            mainForm.Visibility = Visibility.Collapsed;
            var item = dg.CurrentItem as MainWindowViewModel;
            orderEdit.ShowOrderEdit(item.id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class MainWindowViewModel
    {
        public int id { get; set; }
        public string abonent { get; set; }
        public string time_order { get; set; }
        public decimal? Bill { get; set; }

    }


}
