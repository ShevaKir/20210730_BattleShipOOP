using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class FourDeckShip : ThreeDeckShip
    {
        protected Coordinate _coordinate4;
        private StateDeck _deck4;

        public FourDeckShip(int x, int y, OrientationShip orientation = OrientationShip.Horizontal)
            : base(x, y, orientation)
        {
            _deck4 = StateDeck.Intact;
            if (orientation == OrientationShip.Horizontal)
            {
                _coordFullShip = new Coordinate[3, 6];
            }
            else
            {
                _coordFullShip = new Coordinate[6, 3];
            }
        }

        public Coordinate Coordinate4
        {
            get
            {
                return _coordinate4;
            }
        }

        public StateDeck Deck4
        {
            get
            {
                return _deck4;
            }
            set
            {
                _deck4 = value;
            }
        }

        public override void SetDamage(int x, int y)
        {

            if (_coordinate4.x == x && _coordinate4.y == y)
            {
                _deck4 = StateDeck.Damaged;
            }
            else
            {
                base.SetDamage(x, y);
            }
        }

        public override bool IsAllDamageDeck()
        {
            if(base.IsAllDamageDeck())
            {
                return _deck4 == StateDeck.Damaged;
            }

            return false;
        }

        protected override void RotateCoordinateShip(OrientationShip orientation)
        {
            base.RotateCoordinateShip(orientation);
            if (orientation == OrientationShip.Horizontal)
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
