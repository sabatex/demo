using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDemo
{
    public class AdapteeTime
    {
        public string CurrentDateTime() => DateTime.Now.ToString();
    }
}
