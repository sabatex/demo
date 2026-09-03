using RestoranClient.Data;
using RestoranClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public event Action<int?, string> LoginResult;
        public int WaiterId { get; set; }
        public User[] Waiters { get; set; }
        private int passwordCounter { get; set; } = 3;

        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            LoginResult?.Invoke(null, string.Empty);
        }
        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            CheckPassword();
            //using (var context = new RestoranDbContext())
            //{
            //    var r = context.Waiters.SingleOrDefault(s => s.Id == WaiterId);
            //    if (r?.Password == passwordPB.Password)
            //    {
            //        LoginResult?.Invoke(r.Id, r.Name);
            //    }
            //    else
            //    {
            //        passwordCounter--;
            //        if (passwordCounter == 0)
            //            LoginResult?.Invoke(null, string.Empty);
            //        errorBlock.Text = $"Пароль введено неправильно, спробуйте ще {passwordCounter} раз.";
            //        errorBlock.Visibility = Visibility.Visible;
            //    }
            //}
        }

        private void CheckPassword()
        {
            using (var context = new RestoranDbContext())
            {
                var r = context.Users.SingleOrDefault(s => s.Id == WaiterId);
                if (r?.Password == passwordPB.Password)
                {
                    LoginResult?.Invoke(r.Id, r.Name);
                }
                else
                {
                    passwordCounter--;
                    if (passwordCounter == 0)
                        LoginResult?.Invoke(null, string.Empty);
                    errorBlock.Text = $"Пароль введено неправильно, спробуйте ще {passwordCounter} раз.";
                    errorBlock.Visibility = Visibility.Visible;
                }
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new RestoranDbContext())
            {
                var r = context.Users.Select(s => new { id = s.Id, name = s.Name }).ToArray();
                waitersCB.ItemsSource = r;
                if (r.Length == 0)
                    throw new Exception("В базі відсутні офіціанти");
                waitersCB.SelectedValue = r[0].id;
            }
        }

        private void passwordPB_GotFocus(object sender, RoutedEventArgs e)
        {
            errorBlock.Visibility = Visibility.Collapsed;
        }

        private void passwordPB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CheckPassword();
        }
    }
}
