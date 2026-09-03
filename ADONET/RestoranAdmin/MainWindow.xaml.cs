using System;
using System.Collections.Generic;
using System.Configuration;
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
using ADONETDemoFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestoranAdmin.Data;

namespace RestoranAdmin
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
            using (var context = new RestoranDbContext())
            {
                var ct = context.ClientTableWaiters.Include("Waiter").Include("ClientTable").SingleOrDefault(s => s.Id == 1);

                // Id - int
                // birhtDay - Date
                // Name - varchar(50)  string (char,varchar,text)
                // Surname - varChar(50)
                // groupId - int



                //context.Waiters.Add(new Waiter { Name="Петро",Password="12345" });
                //context.Waiters.Add(new Waiter { Name = "Сидор", Password = "12345" });
                //context.Waiters.Add(new Waiter { Name = "Степан", Password = "12345" });
                //context.Waiters.Add(new Waiter { Name = "Василь", Password = "12345" });
                //var p = context.Waiters.SingleOrDefault(s => s.Id == 1);
                //context.Waiters.Remove(p);

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.Configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .AddUserSecrets<App>()
                  .Build();

            var optionBuilder = new DbContextOptionsBuilder();
            App.DbContextOption = optionBuilder.UseSqlite(App.Configuration.GetSection("ConnectionStrings")["sqlite"]).Options;

            int getA(string s)
            {
                return int.Parse(s);
            }

            var i = getA("10");
            var b = getA("9") + getA("5");

            //var a = new {Name = "Pedro",SurName = "Ivano" };

            //var bc = a.Name;


            using (var context = new RestoranDbContext())
            {
                var a = context.ClientTableWaiters.Include("ClientTable").Include("Waiter").
                    Select(s=> new {ClientTableName=s.ClientTable.Name,WaiterName = s.Waiter.Name,id=s.Id }).ToArray();
            }


            var s = new Waiter();


            waiterEdet.Show();
        }
    }
}
