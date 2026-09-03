using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public abstract class Figure
    {
        public readonly FigureColor Color;
        public abstract MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid);
        
        public bool CanMove(SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            for (int i=0;i<8;i++)
            {
                for (int j=0;j<8;j++)
                {
                    var s = CheckMove(new SFigurePosition(i, j), currPos, ref deskGrid);
                    if (s == MoveState.Can)
                        return true;

                }
            }
            return false;

        }
        public abstract byte[] GetImage();
        public abstract int FigureOrder { get; }
        public Figure(FigureColor color)
        {
            Color = color;
        }
    }
}