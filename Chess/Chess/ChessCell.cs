using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class ChessCell
    {
        public Figure Figure { get; set; }
        public DestinationCell[] DestinationCells { get; set; }
    }
}
