using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class SingleDeckShip : Ship
    {
        private StateDeck _deck1;

        public SingleDeckShip(int x, int y)
            : base(x, y)
        {
            _coordFullShip = new Coordinate[3, 3];
            _deck1 = StateDeck.Intact;
        }

        public override Coordinate Coordinate1
        {
            get
            {
                return _coordinate1;
            }             
        }

        public StateDeck Deck1
        {
            get
            {
                return _deck1;
            }
            set
            {
                _deck1 = value;
            }
        }

        public override Coordinate this[int indexX, int indexY]
        {
            get
            {
                return _coordFullShip[indexX, indexY];
            }
        }

        public override int SizeWidth
        {
            get
            {
                return _coordFullShip.GetLength(0);
            }
        }

        public override int SizeHeigh
        {
            get
            {
                return _coordFullShip.GetLength(1);
            }
        }


        public override void FillAroundShip()
        {
            int iteratorX = -1;
            int iteratorY = -1;

            for (int i = 0; i < _coordFullShip.GetLength(0); i++)
            {
                for (int j = 0; j < _coordFullShip.GetLength(1); j++)
                {
                    _coordFullShip[i, j] = new Coordinate()
                    {
                        x = _coordinate1.x + iteratorX,
                        y = _coordinate1.y + iteratorY
                    };
                    iteratorX++;
                }
                iteratorX = -1;
                iteratorY++;
            }
        }

        public override void SetDamage(int x, int y)
        {
            if(_coordinate1.x == x && _coordinate1.y == y)
            {
                _deck1 = StateDeck.Damaged;
            }

        }
        
        public override bool IsAllDamageDeck()
        {
            return _deck1 == StateDeck.Damaged;
        }

    }
}