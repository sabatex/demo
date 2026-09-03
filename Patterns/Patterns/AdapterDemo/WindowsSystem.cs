using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDemo
{
    public class WindowsSystem
    {
        public IEnumerable<string> GetDirectories(string path)
        {
            yield return "Programm Files";
            yield return "Windows";
            yield return "Users";
        }
        public IEnumerable<string> GetFiles(string path)
        {
            yield return "base.ini";
            yield return "bare.txt";
            yield return "tt.json";
        }
        public IEnumerable<string> GetDevices()
        {
            yield return "A:";
            yield return "C:";
            yield return "D:";
        }

        public string GetSystemTime() => DateTime.Now.ToString();

    }
}
