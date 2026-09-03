using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETDemoFramework.Models
{
   
    public class OrderItem
    {
        [Key]
        public string PK { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public FoodItem FoodItem { get; set; }
        public int FoodItemId { get; set; }
        public Double Count { get; set; }
        [Column("Ціна",TypeName ="decimal(9,2)")]
        public Double Price { get; set; } 
    }
}
