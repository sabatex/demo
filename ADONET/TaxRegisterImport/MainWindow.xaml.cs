using Microsoft.Win32;
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
using TaxRegisterImport.Data;
using TaxRegisterImport.Models;

namespace TaxRegisterImport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<RegisterTax> RegisterTax { get; set; }=new ObservableCollection<RegisterTax>(); 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            var of = new OpenFileDialog();
            if (false)
            {
                if (of.ShowDialog() ?? false)
                {
                    var colection = new List<RegisterTax>();
                    int count = 0;
                    RegisterTax.Clear();
                    var file = File.OpenText(of.FileName);
                    var header = file.ReadLine();
                    while (!file.EndOfStream)
                    {
                        var str = file.ReadLine();
                        var arr = str.Split(";");
                        var r_tax = new RegisterTax
                        {
                            Id = str,
                            name = arr[0],
                            tin = arr[1],
                            data_n = arr[2],
                            stavka = arr[3],
                            grup = arr[4],
                            vd = arr[5],
                            data_k = arr[6]
                        };

                        colection.Add(r_tax);
                        count++;
                        if (count > 10000)
                        {
                            using (var context = new RegisterDbContext())
                            {
                                context.MyProperty.AddRange(colection);
                                context.SaveChanges();
                                count = 0;
                                colection.Clear();
                            }

                        }
                    }



                }


            }
                using (var context = new RegisterDbContext())
                {
                    var r = context.MyProperty.ToArray();
                    
                    dg.ItemsSource = new ObservableCollection<RegisterTax>(r);
                }
 
        }
    }
}
