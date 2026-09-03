using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class King : Figure
    {
        static bool check = true;

        public King(FigureColor Color) : base(Color)
        {

        }

        public override int FigureOrder => 0;

        public override MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(currPos))
            {
                return MoveState.Cannot;
            }

            if (newPos.X == currPos.X + 1 && newPos.Y == currPos.Y ||
                newPos.X == currPos.X + 1 && newPos.Y == currPos.Y + 1 ||
                newPos.X == currPos.X + 1 && newPos.Y == currPos.Y - 1 ||
                newPos.X == currPos.X - 1 && newPos.Y == currPos.Y ||
                newPos.X == currPos.X - 1 && newPos.Y == currPos.Y + 1 ||
                newPos.X == currPos.X - 1 && newPos.Y == currPos.Y - 1 ||
                newPos.X == currPos.X && newPos.Y == currPos.Y + 1 ||
                newPos.X == currPos.X && newPos.Y == currPos.Y - 1)
            {
                Figure tempFig = deskGrid[newPos.X, newPos.Y];

                if (tempFig != null && tempFig?.Color == this.Color)
                {
                    return MoveState.Cannot;
                }

                if (check)
                {
                    check = !check;
                    deskGrid[newPos.X, newPos.Y] = this;

                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (deskGrid[i, j]?.Color != this.Color &&
                                deskGrid[i, j]?.CheckMove(newPos, new SFigurePosition(i, j), ref deskGrid) == MoveState.Fight)
                            {
                                deskGrid[newPos.X, newPos.Y] = tempFig;
                                check = !check;
                                return MoveState.Cannot;
                            }
                        }
                    }
                    deskGrid[newPos.X, newPos.Y] = tempFig;
                    check = !check;
                }

                if (tempFig == null)
                {
                    return MoveState.Can;
                }
                return MoveState.Fight;
            }
            return MoveState.Cannot;
        }

        public override byte[] GetImage()
        {
            if (Color == FigureColor.White)
                return ResourceImages.KingWhite;
            else
                return ResourceImages.KingBlack;
        }
    }
}
