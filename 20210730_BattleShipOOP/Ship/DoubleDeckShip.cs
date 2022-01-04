using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class DoubleDeckShip : SingleDeckShip
    {
        private OrientationShip _orientation;          // true - Vertical , false - Horizontal
        protected Coordinate _coordinate2;
        private StateDeck _deck2;

        public DoubleDeckShip(int x, int y, OrientationShip orientation = OrientationShip.Horizontal)
            :base(x, y)
        {
            _deck2 = StateDeck.Intact;
            _orientation = orientation;

            if (_orientation == OrientationShip.Horizontal)
            {
                _coordFullShip = new Coordinate[3, 4];
            }
            else
            {
                _coordFullShip = new Coordinate[4, 3];
            }

            RotateCoordinateShip(orientation);
        }

        public Coordinate Coordinate2
        {
            get
            {
                return _coordinate2;
            }
        }

        public StateDeck Deck2
        {
            get
            {
                return _deck2;
            }
            set
            {
                _deck2 = value;
            }
        }

        public override void SetDamage(int x, int y)
        {
            
            if (_coordinate2.x == x && _coordinate2.y == y)
            {
                _deck2 = StateDeck.Damaged;
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
                return _deck2 == StateDeck.Damaged;
            }

            return false;  
        }

        protected virtual void RotateCoordinateShip(OrientationShip orientation)
        {
            if(orientation == OrientationShip.Horizontal)
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