using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDemo
{
    public class WindowsAdapter : Target
    {
        private WindowsSystem _adaptee = new WindowsSystem();
        public override string[] GetCatalogs(string path)
        {
            return _adaptee.GetDirectories(path).ToArray();
        }

        public override string[] GetDisks()
        {
            return _adaptee.GetDevices().ToArray();
        }

        public override string[] GetFiles(string path)
        {
            return _adaptee.GetFiles(path).ToArray();
        }
        public override DateTime CurrentDate()
        {
            return DateTime.Parse(_adaptee.GetSystemTime());
        }

    }
}
