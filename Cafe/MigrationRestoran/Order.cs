using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationRestoran
{
    public partial class Order
    {
        public Order()
        {
            Details = new HashSet<Details>();
        }

        public DateTime TimeOrder { get; set; }
        public DateTime? EndOrder { get; set; }
        public decimal? Bill { get; set; }

        public int Id { get; set; }
        public int? WaiterId { get; set; }
        public int? AbonentId { get; set; }
        public int? SourceId { get; set; }

        public virtual ICollection<Details> Details { get; set; }
    }
}
