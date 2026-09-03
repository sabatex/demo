using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDemo
{
    public abstract class Target //FileSystem
    {
        public virtual DateTime CurrentDate()=> DateTime.Now;
        public abstract string[] GetCatalogs(string path);
        public abstract string[] GetFiles(string path);
        public abstract string[] GetDisks();
 
    }
}
