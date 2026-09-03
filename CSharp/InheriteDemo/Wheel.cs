using System;
using System.Collections.Generic;
using System.Text;

namespace InheriteDemo
{



    public abstract class Wheel
    {
        
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        virtual public  double CalcLength()
        {
            return radius * 2 * Math.PI;
        }

        public double CalcSquare()
        {
            return Math.PI * radius * radius;
        }
        public Wheel()
        {
            radius = 1;

        }
        public Wheel(double radius)
        {
            this.radius = radius;
        }

        public abstract void RotateLeft(double angle);
        public abstract void RotateRight(double angle);

    }
}
