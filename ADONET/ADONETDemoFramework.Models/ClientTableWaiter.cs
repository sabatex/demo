using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETDemoFramework.Models
{
    public class ClientTableWaiter
    {
        public int Id { get; set; }
        public ClientTable ClientTable { get; set; }
        public int ClientTableId { get; set; } // many count(1) = many

        public Waiter Waiter { get; set; }
        public int WaiterId { get; set; }
    }
}
