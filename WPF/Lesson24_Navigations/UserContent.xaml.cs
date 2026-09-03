using System;
using System.Collections.Generic;
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

namespace Lesson24_Navigations
{
    /// <summary>
    /// Interaction logic for UserContent.xaml
    /// </summary>
    public partial class UserContent : Page
    {
        public UserContent()
        {
            InitializeComponent();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            login.Content = App.UserLogin;
            password.Content = App.Password;

        }
    }
}
