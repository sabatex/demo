using System;
using System.Collections.Generic;
using System.Text;

namespace InheriteDemo
{
    public sealed class GumWheel:Wheel
    {
        public string TypeGum { get; set; }
        public double WidthGum { get; set; }


        public override double CalcLength()
        {
            return 2*(Radius+WidthGum)*Math.PI;
        }

        public double CalcSquare()
        {
            return Math.PI * (Radius + WidthGum) * (Radius + WidthGum);
        }

        public GumWheel(double radius):base(radius)
        {
            

                
        }

        

        private GumWheel(double radius,string typeGum):base(radius)
        {


            this.TypeGum = typeGum;
        }
        private GumWheel():base()
        {
                
        }


        public static GumWheel GetGumWheel(double radius,string typeGum)
        {
            double a = 50;


            return new GumWheel(radius, typeGum);
        }

        public override void RotateLeft(double angle)
        {
            throw new NotImplementedException();
        }

        public override void RotateRight(double angle)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Резинове колесо з радіусом {Radius} та товщиною гуми {WidthGum}";
        }

    }
}
