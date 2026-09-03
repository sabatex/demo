using System;
using System.Collections.Generic;

namespace MigrationRestoran
{
    public partial class Details
    {
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal Bill { get; set; }
        public int OrderId { get; set; }
        public int Id { get; set; }
        public int? ItemsId { get; set; }

        public virtual Order Order { get; set; }
    }
}
