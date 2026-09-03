using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    public struct WheelStruct : ICircle,IComparable
    {
        double radius;
        public double Radius { get => radius; set => radius= value; }
        public double Diameter { get => radius * 2; set => radius = value/2; }

        public int CompareTo(object obj)
        {
            WheelStruct wheel = (WheelStruct)obj;
            if (radius == wheel.radius) return 0;
            if (radius > wheel.radius)
                return 1;
            else
                return -1;
        }

        public double GetLength()
        {
            return radius*radius*Math.PI;
        }
    }
}
