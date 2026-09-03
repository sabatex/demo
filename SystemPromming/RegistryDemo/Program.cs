// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;

using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Google"))
{
    var l = registryKey?.GetValue("Path");
    Console.WriteLine($"{l}");
}

