using System;

namespace AdapterDemo
{
    class Program
    {
        static void ShowFileSystem(Target target)
        {
            Console.WriteLine($"Current date: {target.CurrentDate()}");
            Console.WriteLine($"Folders:");
            foreach (var item in target.GetCatalogs(""))
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"Files:");
            foreach (var item in target.GetFiles(""))
            {
                Console.WriteLine($"{item}");
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Windows File System:");
            Target target= new WindowsAdapter();
            ShowFileSystem(target);
            target = new LinuxAdapter();
            Console.WriteLine($"Linux File System:");
            ShowFileSystem(target);

        }
    }
}
