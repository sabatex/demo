using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp;

internal class IoDemo
{
    static List<string> list = new List<string>();
    static int counter;

    static void getDirectorys(string path)
    {

        try
        {
            foreach (var d in Directory.GetDirectories(path))
            {
                //list.Add(d);
                counter++;
                getDirectorys(d);
            }

        }
        catch
        {
            //list.Add($"Access denied {path}");
        }

    }

    static void getDirectorysE(string path)
    {
        try
        {
            foreach (var d in Directory.EnumerateDirectories(path))
            {
                //list.Add(d);
                counter++;
                getDirectorysE(d);
            }

        }
        catch
        {
            //list.Add($"Access denied {path}");
        }

    }

    static void Go(string[] args)
    {

        var st = File.OpenRead("");
        var ch = new BinaryReader(st);

        list.Clear();
        counter = 0;
        var dt = DateTime.Now;
        Console.WriteLine($"Start - {dt}");
        getDirectorys(@"C:\");
        Console.WriteLine($"End - {DateTime.Now}");
        Console.WriteLine($"Items - {counter}");
    }
}
