using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MonoCicle.Models
{
    public class KeyboardState
    {
        public Direction CurentDirection 
        { 
            get
            {
                if (_left == _right)
                    return Direction.None;
                if (_left)
                    return Direction.Forward;
                return Direction.Back;
            }
        }

        bool _left;
        bool _right;
        bool _PowerUp;
        bool _PowerDown;


        public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    _left = true;
                    break;
                case Key.Right:
                    _right = true;
                    break;
                case Key.Q:
                    _PowerUp = true;
                    break;
                case Key.A:
                    _PowerDown = true;
                    break;
            }
        }

        public void KeyUp(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    _left = false;
                    break;
                case Key.Right:
                    _right = false;
                    break;
                case Key.Q:
                    _PowerUp = false;
                    break;
                case Key.A:
                    _PowerDown = false;
                    break;
            }
        }
    }
}
