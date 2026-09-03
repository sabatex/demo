using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETDemoFramework.Models
{
    [Table("Офіціант",Schema = "mybase")]
    public class Waiter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(18)]
        public string Password { get; set; }
        public List<ClientTableWaiter> ClientTableWaiters { get; set; }
    }
}
