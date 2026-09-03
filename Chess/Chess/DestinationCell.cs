using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class DestinationCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public MoveState State { get; set; }
    }
}
