using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Rook : Figure
    {
        public Rook(FigureColor Color) : base(Color)
        {

        }

        public override int FigureOrder => 4;

        public override MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(currPos))
            {
                return MoveState.Cannot;
            }

            Figure fig = deskGrid[newPos.X, newPos.Y];

            if (fig?.Color == this.Color)
            {
                return MoveState.Cannot;
            }

            if (newPos.X == currPos.X && newPos.Y != currPos.Y)
            {
                int idx = -1;
                if (newPos.Y > currPos.Y)
                {
                    idx *= -1;
                }

                for (int i = currPos.Y + idx; i != newPos.Y; i += idx)
                {
                    if (deskGrid[currPos.X, i] != null)
                    {
                        return MoveState.Cannot;
                    }
                }

                if (fig != null)
                {
                    return MoveState.Fight;
                }

                return MoveState.Can;
            }

            if (newPos.X != currPos.X && newPos.Y == currPos.Y)
            {
                int idx = -1;
                if (newPos.X > currPos.X)
                {
                    idx *= -1;
                }

                for (int i = currPos.X + idx; i != newPos.X; i += idx)
                {
                    if (deskGrid[i, currPos.Y] != null)
                    {
                        return MoveState.Cannot;
                    }
                }

                if (fig != null)
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
                return ResourceImages.RockWhite;
            else
                return ResourceImages.RockBlack;
        }
    }
}
