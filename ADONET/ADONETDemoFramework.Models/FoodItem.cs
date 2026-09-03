using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETDemoFramework.Models
{

    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public string Description { get; set; }
    }
}
