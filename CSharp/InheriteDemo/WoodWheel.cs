using System;
using System.Collections.Generic;
using System.Text;

namespace InheriteDemo
{
    public class WoodWheel : Wheel
    {
        public double WidthGrip;
        public override string ToString()
        {
            return  $"Деревяне колесо з радіусом {Radius} та товщиною обода {WidthGrip}";
        }

        public override void RotateLeft(double angle)
        {
            throw new NotImplementedException();
        }

        public override void RotateRight(double angle)
        {
            throw new NotImplementedException();
        }
    }
}
