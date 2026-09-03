using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileAbstractFactoryDemo
{
    public class ChryslerBodyClassic : AbstractAutomobileBody
    {
        public override double Weight => 1300;
    }
}
