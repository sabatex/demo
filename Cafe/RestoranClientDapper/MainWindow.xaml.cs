using Dapper;
using Microsoft.Data.SqlClient;
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
            //using (var context = new RestoranDbContext())
            //{
            //    var r = context.Order.Where(w => w.WaiterId == Config.WaiterId)
            //       .Join(context.Abonent, ws => ws.AbonentId, ab => ab.Id, (ws, ab) => new MainWindowViewModel { id = ws.Id, time_order = ws.TimeOrder.ToString("H:mm:ss"), abonent = ab.Name, Bill = ws.Bill }).ToArray();
            //    dg.ItemsSource = new ObservableCollection<MainWindowViewModel>(r);
            //}



            using (var connection = new SqlConnection(Config.ConnectionString))
            {
                string sqlmainWindowViewModel = $"select [Order].Id, [Order].time_order,[Order].Bill,[abonent].name as abonent  from [Order] left join abonent on abonent.id = [Order].abonent_id where[Order].waiter_id = @waiter_id";
                var r = connection.Query<MainWindowViewModel>(sqlmainWindowViewModel,new { waiter_id = Config.WaiterId }).ToArray();

                dg.ItemsSource = new ObservableCollection<MainWindowViewModel>(r);

                // Stored procedure
                // INSERT statement
                // UPDATE statement
                // DELETE statement
                var i = connection.Execute(sqlmainWindowViewModel, new { waiter_id = Config.WaiterId });
                // ExecuteScalar
                var sc = connection.ExecuteScalar<int>("Select Id from Waiters");




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
            
            orderEdit.ShowOrderEdit();
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
                var connect = context.Database.GetDbConnection();
                connect.BeginTransaction();
                if (obj.Id == 0)
                {
                    obj.Id = connect.ExecuteScalar<int>("SELECT IDENT_CURRENT('Order')");
                    connect.Execute("INSERT INTO [Order] (Id,[waiter_id],[abonent_id],[time_order],[Bill],[FixedSource]) VALUES(@Id, @waiter_id, @abonent_id, @time_order, @Bill, @FixedSource); ",new { Id = obj.Id, waiter_id = obj.WaiterId, abonent_id = obj.AbonentId, time_order = obj.TimeOrder, Bill = obj.Bill, FixedSource= obj.FixedSource });
                }
                else
                {
                    connect.Execute("UPDATE [Order] SET waiter_id =  @waiter_id, abonent_id = @abonent_id, time_order = @time_order, Bill = @Bill, FixedSource = @FixedSource,end_order = @end_order,Paid = @Paid)  WHERE Id=@Id; ", new { Id = obj.Id, waiter_id = obj.WaiterId, abonent_id = obj.AbonentId, time_order = obj.TimeOrder, Bill = obj.Bill, FixedSource = obj.FixedSource, end_order = obj.EndOrder, Paid = obj.Paid });
                }
                foreach (var item in obj.Details)
                {
                    if (item.Id==0)
                    {
                        item.OrderId = obj.Id;
                    }
                    else
                    {

                    }
                }
 
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
                login.Visibility = Visibility.Hidden;
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
