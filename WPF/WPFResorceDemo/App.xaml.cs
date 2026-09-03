using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace WPFResorceDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);
            this.Resources.MergedDictionaries.Clear();
            var r = new ResourceDictionary();
            r.Source = new Uri("WhiteThemeDictionary.xaml");
            this.Resources.MergedDictionaries.Add(r);
        }
    }
}
