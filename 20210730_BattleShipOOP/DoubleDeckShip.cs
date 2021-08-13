using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class DoubleDeckShip : SingleDeckShip
    {
        private bool _orientation;          // true - Horizontal , false - Vertical
        protected Coordinate _coordinate2;

        public DoubleDeckShip(int x, int y, bool orientation = true)
            :base(x, y)
        {
            _coordinate2.state = StateCell.Ship;
            _orientation = orientation;
            RotateCoordinateShip(orientation);
        }

        public Coordinate Coordinate2
        {
            get
            {
                return _coordinate2;
            }
        }

        protected virtual void RotateCoordinateShip(bool orientation)
        {
            if(orientation)
            {
                _coordinate2.x = _coordinate1.x + 1;
                _coordinate2.y = _coordinate1.y;
            }
            else 
            {
                _coordinate2.x = _coordinate1.x;
                _coordinate2.y = _coordinate1.y + 1;
            }
        }

    }
}