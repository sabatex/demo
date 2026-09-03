using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETDemoFramework.Models
{
    public class ClientTable
    {
        public int Id { get; set; } //one to one  1
        public string Name { get; set; }
        [NotMapped]
        public Guid Version { get; set; }
    }
}
