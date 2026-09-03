using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDemo
{
    public class LinuxAdapter : Target
    {
        private LinuxDiskSustem _adaptee = new LinuxDiskSustem();
        public override string[] GetCatalogs(string path)
        {
            return _adaptee.GetFileDescriptors(path)
                .Where(s => s.FileType == FileType.Folder)
                .Select(r => r.Name)
                .ToArray();

        }

        public override string[] GetDisks()
        {
            return new string[] { };
        }

        public override string[] GetFiles(string path)
        {
            return _adaptee.GetFileDescriptors(path)
                           .Where(s=>s.FileType == FileType.File)
                           .Select(r=>r.Name)
                           .ToArray();
        }
    }
}
