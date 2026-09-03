using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public partial class Wheel
    {
        // comment
        /// <summary>
        /// Загальна ширина колеса
        /// </summary>
        public static int Width;

        string Name;

        #region for my code
        private decimal diameter;
        decimal Diameter { get=>diameter; set=>diameter=value; }
        public decimal DiameterL
        {
            get
            {
                return Radius * 2;
            }
            set
            {
                Radius = value / 2;
            }
        }
        public void SetDiameter(decimal diameter,out Wheel wheel)
        {
            Radius = diameter / 2;
            wheel = new Wheel(Radius);
        }
        public decimal GetDiameter()
        {
            return 2 * Radius;
        }
        #endregion property
        public decimal GetSquare()
        {
            return (decimal)Math.PI * Radius * Radius;
        }

        public static decimal CalcDiametr(Wheel wheel)
        {
            Width = 10;
            return wheel.GetDiameter();
        }
        public static decimal CalcDiametr(decimal radius,object[] any)
        {
            int i = any.Length;
            return radius * 2;
        }

        public (decimal,decimal) Calc()
        {
            return (Radius * 2,(decimal)Math.PI *Radius*Radius);
        }


        public decimal Radius;
        public void SetGet() { }

    }
}
