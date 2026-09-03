using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxRegisterImport.Models
{
    public class RegisterTax
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string tin { get; set; }
        public string data_n { get; set; }
        public string stavka  { get; set; }
        public string grup { get; set; }
        public string vd { get; set; }
        public string data_k { get; set; }
    }
}
