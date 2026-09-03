using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    public class Product
    {
        private List<string> _parts = new List<string>();
        public void Add(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var result = new StringBuilder("Product Parts:\n");
            foreach (string part in _parts) result.Append($"{part}\n");
            return result.ToString();
        }
    }

}
