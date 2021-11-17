using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class ThreeDeckShip : DoubleDeckShip
    {
        protected Coordinate _coordinate3;
        private StateDeck _deck3;

        public ThreeDeckShip(int x, int y, bool orientation = true)
            :base(x, y, orientation)
        {
            _deck3 = StateDeck.Intact;
            if (orientation)
            {
                _coordFullShip = new Coordinate[3, 5];
            }
            else
            {
                _coordFullShip = new Coordinate[5, 3];
            }
        }

        public Coordinate Coordinate3
        {
            get
            {
                return _coordinate3;
            }
        }

        public StateDeck Deck3
        {
            get
            {
                return _deck3;
            }
            set
            {
                _deck3 = value;
            }
        }

        public override void SetDamage(int x, int y)
        {

            if (_coordinate3.x == x && _coordinate3.y == y)
            {
                _deck3 = StateDeck.Damaged;
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
                return _deck3 == StateDeck.Damaged;
            }

            return false;
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