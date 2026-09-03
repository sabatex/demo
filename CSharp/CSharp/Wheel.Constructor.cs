using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public partial class Wheel
    {
        public Wheel()
        {
            Radius = 5;
        }
        public Wheel(decimal Radius)
        {
            this.Radius = Radius;
        }

        static Wheel()
        {
            Width = 10;

        }

    }
}
