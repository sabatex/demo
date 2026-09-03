using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    public interface ICircle
    {
        double Radius { get; set; }
        double Diameter { get; set; }
        double GetLength();
    }
}
