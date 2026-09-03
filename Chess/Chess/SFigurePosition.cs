using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct SFigurePosition
    {
        private int _x;
        private int _y;

        public readonly int X { get { return _x; } }
        public readonly int Y { get { return _y; } }

        public SFigurePosition(int x, int y)
        {
            if (x < -1 || x > 7 || y < -1 || y > 7)
            {
                throw new Exception();
            }

            _x = x;
            _y = y;
        }
        public void SetPosition(int x, int y)
        {
            if (x < -1 || x > 7 || y < -1 || y > 7)
            {
                throw new Exception();
            }

            _x = x;
            _y = y;
        }
        bool Equals(SFigurePosition obj)
        {
            if (_x == obj._x && _y == obj._y)
            {
                return true;
            }
            return false;
        }
    }
}
