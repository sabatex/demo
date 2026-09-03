using System;
using System.Collections.Generic;
using System.Text;

namespace RestoranClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? WaiterId { get; set; }

        public int? AbonentId { get; set; }
        public Abonent Abonent { get; set; }
        public DateTime TimeOrder { get; set; }
        public decimal? Bill { get; set; }

        //public int? SourceId { get; set; }

        public FixSource FixedSource { get; set; }
        public DateTime? EndOrder { get; set; }
        public decimal Paid { get; set; }
        public List<Detail> Details { get; set; }

    }
}
