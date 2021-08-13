using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class ThreeDeckShip : DoubleDeckShip
    {
        protected Coordinate _coordinate3;

        public ThreeDeckShip(int x, int y, bool orientation = true)
            :base(x, y, orientation)
        {
            _coordinate3.state = StateCell.Ship;
        }

        public Coordinate Coordinate3
        {
            get
            {
                return _coordinate3;
            }
        }

        protected override void RotateCoordinateShip(bool orientation)
        {
            base.RotateCoordinateShip(orientation);
            if (orientation)
            {
                _coordinate3.x = _coordinate2.x + 1;
                _coordinate3.y = _coordinate2.y;
            }
            else
            {
                _coordinate3.x = _coordinate2.x;
                _coordinate3.y = _coordinate2.y + 1;
            }

        }

    }
}