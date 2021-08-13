using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class FourDeckShip : ThreeDeckShip
    {
        private Coordinate _coordinate4;

        public FourDeckShip(int x, int y, bool orientation = true)
            : base(x, y, orientation)
        {
            _coordinate4.state = StateCell.Ship;
        }

        public Coordinate Coordinate4
        {
            get
            {
                return _coordinate4;
            }
        }

        protected override void RotateCoordinateShip(bool orientation)
        {
            base.RotateCoordinateShip(orientation);
            if (orientation)
            {
                _coordinate4.x = _coordinate3.x + 1;
                _coordinate4.y = _coordinate3.y;
            }
            else
            {
                _coordinate4.x = _coordinate3.x;
                _coordinate4.y = _coordinate3.y + 1;
            }

        }

    }
}
