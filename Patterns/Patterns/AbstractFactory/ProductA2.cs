using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class ProductA2 : AbstractProductA
    {
        string _name = "This is a product A2";
        public override string Name { get => _name; set => _name = value; }

    }
}
