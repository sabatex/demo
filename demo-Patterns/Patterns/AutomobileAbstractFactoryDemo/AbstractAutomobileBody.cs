using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileAbstractFactoryDemo
{
    public abstract class AbstractAutomobileBody : IAutomobileParams
    {
        public abstract double Weight { get; }
    }
}
