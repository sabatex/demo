using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETDemoFramework.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int WaiterId { get; set; }
        public ClientTable ClientTable { get; set; }
        public int ClientTableId { get; set; }
        public  DateTime Date { get; set; }
    }
}
