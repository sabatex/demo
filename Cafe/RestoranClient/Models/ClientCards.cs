using System;
using System.Collections.Generic;

namespace RestoranClient.Models
{
    public partial class ClientCards
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
    }
}
