using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class GameField
    {
        private const int SIZE = 10;
        private Cell[,] _cells;

        public GameField()
        {
            _cells = new Cell[SIZE, SIZE];
        }

        public bool IsFreePlace(ParametrShip ship)
        {
            bool result = false;

            if (ship.orientation)
            {
                if(ship.coordinate.x + ship.countDeck < SIZE)
                {
                    for (int i = ship.coordinate.x; i < ship.coordinate.x + ship.countDeck; i++)
                    {
                        if (_cells[i, ship.coordinate.y] == null)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                }  
            }
            else
            {
                if(ship.coordinate.y + ship.countDeck < SIZE)
                {
                    for (int i = ship.coordinate.y; i < ship.coordinate.y + ship.countDeck; i++)
                    {
                        if (_cells[ship.coordinate.x, i] == null)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                } 
            }

            return result;
        }

        public void AddShip(ParametrShip sourceShip)
        {

            switch (sourceShip.countDeck)
            {
                case 1:
                    SingleDeckShip singleShip = 
                            new SingleDeckShip(sourceShip.coordinate.x, sourceShip.coordinate.y);

                    _cells[singleShip.Coordinate1.x, singleShip.Coordinate1.y] = singleShip;
                    break;
                case 2:
                    DoubleDeckShip doubleShip = new DoubleDeckShip(sourceShip.coordinate.x, 
                            sourceShip.coordinate.y, sourceShip.orientation);

                    _cells[doubleShip.Coordinate1.x, doubleShip.Coordinate1.y] = doubleShip;
                    _cells[doubleShip.Coordinate2.x, doubleShip.Coordinate2.y] = doubleShip;
                    break;
                case 3:
                    ThreeDeckShip threeShip = new ThreeDeckShip(sourceShip.coordinate.x,
                            sourceShip.coordinate.y, sourceShip.orientation);

                    _cells[threeShip.Coordinate1.x, threeShip.Coordinate1.y] = threeShip;
                    _cells[threeShip.Coordinate2.x, threeShip.Coordinate2.y] = threeShip;
                    _cells[threeShip.Coordinate3.x, threeShip.Coordinate3.y] = threeShip;
                    break;
                case 4:
                    FourDeckShip fourShip = new FourDeckShip(sourceShip.coordinate.x,
                            sourceShip.coordinate.y, sourceShip.orientation);

                    _cells[fourShip.Coordinate1.x, fourShip.Coordinate1.y] = fourShip;
                    _cells[fourShip.Coordinate2.x, fourShip.Coordinate2.y] = fourShip;
                    _cells[fourShip.Coordinate3.x, fourShip.Coordinate3.y] = fourShip;
                    _cells[fourShip.Coordinate4.x, fourShip.Coordinate4.y] = fourShip;
                    break;
                default:
                    break;
            }
        }

    }
}