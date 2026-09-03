using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Player
    {
        public FigureColor Color { get; }
        public List<string> _moves;
        public List<Figure> _deadFigures;

        public Player(FigureColor color)
        {
            Color = color;
            _moves = new List<string>();
            _deadFigures = new List<Figure>();            
        }
    }
}