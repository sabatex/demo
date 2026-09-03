using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Models
{
    public class Figure
    {
        public FigureColor  Color { get; set; }
        public bool FistMove { get; set; } = true;
        public FigureType FigureType { get; set; }
        public DestinationCell[] CanMoves { get; set; }

        public int Direction { get=> Color == FigureColor.White?-1:1; }

    }
}
