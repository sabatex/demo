using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestoranClient.Models
{
   public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public bool IsMark { get; set; }
        [NotMapped]
        public decimal Count { get; set; }

    }
}
