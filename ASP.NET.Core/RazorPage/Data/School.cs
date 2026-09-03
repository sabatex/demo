using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage.Data
{
    public class School
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string UserId { get; set; }//1,2
        public override string ToString()
        {
            return Name;
        }
    }
}
