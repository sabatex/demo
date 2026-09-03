using System;
using System.Collections.Generic;
using System.Text;

namespace RestoranClient.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public int ItemsId { get; set; }
        public int OrderId { get; set; }
        public decimal Bill { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
    }
}
