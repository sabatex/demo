using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Bishop : Figure
    {
        public Bishop(FigureColor Color) : base(Color)
        {

        }

        public override int FigureOrder => 2;

        public override MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(currPos) ||
                newPos.X == currPos.X && newPos.Y != currPos.Y ||
                newPos.X != currPos.X && newPos.Y == currPos.Y ||
                deskGrid[newPos.X, newPos.Y]?.Color == this.Color
                )
            {
                return MoveState.Cannot;
            }

            int idx = 1;
            int idy = 1;

            if (newPos.X > currPos.X && newPos.Y < currPos.Y)
            {
                idy *= -1;
            }

            if (newPos.X < currPos.X && newPos.Y > currPos.Y)
            {
                idx *= -1;
            }

            if (newPos.X < currPos.X && newPos.Y < currPos.Y)
            {
                idx *= -1;
                idy *= -1;
            }

            int x = currPos.X + idx;
            int y = currPos.Y + idy;

            for (; x != newPos.X && y != newPos.Y; x += idx, y += idy)
            {
                if (deskGrid[x, y] != null)
                {
                    return MoveState.Cannot;
                }
            }

            if (x == newPos.X && y == newPos.Y)
            {
                if (deskGrid[x, y] != null)
                {
                    return MoveState.Fight;
                }
                return MoveState.Can;
            }
            return MoveState.Cannot;
        }

        public override byte[] GetImage()
        {
            if (Color == FigureColor.White)
                return ResourceImages.BishopWhite;
            else
                return ResourceImages.BishopBlack;
        }
    }
}
