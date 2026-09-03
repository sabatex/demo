using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDemo
{
    public enum FileType
    {
        File,Folder
    }

    public class FileDescriptor
    {
        public string Name { get; set; }
        public FileType FileType { get; set; }
    }
    public class LinuxDiskSustem
    {
        public IEnumerable<FileDescriptor> GetFileDescriptors(string path)
        {
            yield return new FileDescriptor {Name =  "etc", FileType= FileType.Folder };
            yield return new FileDescriptor { Name = "home", FileType = FileType.Folder };
            yield return new FileDescriptor { Name = "demo.txt", FileType = FileType.File };
            yield return new FileDescriptor { Name = "_.json", FileType = FileType.File };
        }
        public long GetSystemTime()=>DateTime.Now.Ticks;

    }
}
