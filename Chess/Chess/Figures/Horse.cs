using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Horse : Figure
    {
        public Horse(FigureColor Color) : base(Color)
        {

        }

        public override int FigureOrder => 3;

        public override MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(currPos))
            {
                return MoveState.Cannot;
            }

            if (newPos.X == currPos.X + 1 && newPos.Y == currPos.Y + 2 ||
                newPos.X == currPos.X + 1 && newPos.Y == currPos.Y - 2 ||
                newPos.X == currPos.X - 1 && newPos.Y == currPos.Y + 2 ||
                newPos.X == currPos.X - 1 && newPos.Y == currPos.Y - 2 ||
                newPos.X == currPos.X + 2 && newPos.Y == currPos.Y + 1 ||
                newPos.X == currPos.X + 2 && newPos.Y == currPos.Y - 1 ||
                newPos.X == currPos.X - 2 && newPos.Y == currPos.Y + 1 ||
                newPos.X == currPos.X - 2 && newPos.Y == currPos.Y - 1)
            {
                Figure fig = deskGrid[newPos.X, newPos.Y];

                if (fig == null)
                {
                    return MoveState.Can;
                }

                if (fig.Color != this.Color)
                {
                    return MoveState.Fight;
                }
            }           

            return MoveState.Cannot;
        }

        public override byte[] GetImage()
        {
            if (Color == FigureColor.White)
                return ResourceImages.HourseWhite;
            else
                return ResourceImages.HourseBlack;
        }
    }
}
