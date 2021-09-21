using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class GameField : IShowField
    {
        private const int SIZE = 10;
        private Cell[,] _cells;
        private int _countShip;
            
        public GameField()
        {
            _cells = new Cell[SIZE, SIZE];
        }

        public Cell this[int xIndex, int yIndex] 
        {
            get
            {
                return _cells[xIndex, yIndex];
            }
        }

        public int SizeField 
        {
            get
            {
                return SIZE;
            }
        }

        public int CountShip
        {
            get
            {
                return _countShip;
            }
        }

        public bool IsFreePlace(ParametrShip ship)
        {
            bool result = false;
            
            if (ship.coordinate.x >= 0 && ship.coordinate.x < SIZE 
                    && ship.coordinate.y >= 0 && ship.coordinate.y < SIZE)
            {
                if (ship.orientation)
                {
                    if (ship.coordinate.x + ship.countDeck <= SIZE)
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
                    if (ship.coordinate.y + ship.countDeck <= SIZE)
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
            }
            else
            {
                throw new OutOfFieldException("Out of field");
            }

            return result;
        }

        public bool IsFreeCell(Coordinate coordinate)
        {
            bool result = false;

            if(!(_cells[coordinate.x, coordinate.y] is HitCell) 
                    && !(_cells[coordinate.x, coordinate.y] is MissCell))
            {
                result = true;
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

                    singleShip.FillAroundShip();
                    _cells[singleShip.Coordinate1.x, singleShip.Coordinate1.y] = singleShip;

                    SetShipToField(singleShip);
                    _countShip++;
                    break;
                case 2:
                    DoubleDeckShip doubleShip = new DoubleDeckShip(sourceShip.coordinate.x, 
                            sourceShip.coordinate.y, sourceShip.orientation);

                    doubleShip.FillAroundShip();
                    _cells[doubleShip.Coordinate1.x, doubleShip.Coordinate1.y] = doubleShip;
                    _cells[doubleShip.Coordinate2.x, doubleShip.Coordinate2.y] = doubleShip;

                    SetShipToField(doubleShip);
                    _countShip++;
                    break;
                case 3:
                    ThreeDeckShip threeShip = new ThreeDeckShip(sourceShip.coordinate.x,
                            sourceShip.coordinate.y, sourceShip.orientation);

                    threeShip.FillAroundShip(); 
                    _cells[threeShip.Coordinate1.x, threeShip.Coordinate1.y] = threeShip;
                    _cells[threeShip.Coordinate2.x, threeShip.Coordinate2.y] = threeShip;
                    _cells[threeShip.Coordinate3.x, threeShip.Coordinate3.y] = threeShip;

                    SetShipToField(threeShip);
                    _countShip++;
                    break;
                case 4:
                    FourDeckShip fourShip = new FourDeckShip(sourceShip.coordinate.x,
                            sourceShip.coordinate.y, sourceShip.orientation);

                    fourShip.FillAroundShip();
                    _cells[fourShip.Coordinate1.x, fourShip.Coordinate1.y] = fourShip;
                    _cells[fourShip.Coordinate2.x, fourShip.Coordinate2.y] = fourShip;
                    _cells[fourShip.Coordinate3.x, fourShip.Coordinate3.y] = fourShip;
                    _cells[fourShip.Coordinate4.x, fourShip.Coordinate4.y] = fourShip;

                    SetShipToField(fourShip);
                    _countShip++;
                    break;
                default:
                    break;
            }
            
        }

        private void SetShipToField(Ship ship)
        {
            for (int i = 0; i < ship.SizeWidth; i++)
            {
                for (int j = 0; j < ship.SizeHeigh; j++)
                {
                    if (ship[i, j].x != -1 && ship[i, j].x != 10
                            && ship[i, j].y != -1 && ship[i, j].y != 10
                                && _cells[ship[i, j].x, ship[i, j].y] == null)
                    {
                        _cells[ship[i, j].x, ship[i, j].y] =
                            new EmptyCell(ship[i, j].x, ship[i, j].y);
                    }
                }
            }
        }


        public void SetShot(Coordinate shot)
        {

            if (_cells[shot.x, shot.y] is Ship ship)
            {
                ship.SetDamage(shot.x, shot.y);
                _cells[shot.x, shot.y] = new HitCell(shot.x, shot.y);
                if(ship.IsAllDamageDeck())
                {
                    KillShip(ship);
                    _countShip--;
                }
            }
            else
            {
                _cells[shot.x, shot.y] = new MissCell(shot.x, shot.y);
            } 
            
        }

        public void KillShip(Ship ship)
        {
            for (int i = 0; i < ship.SizeWidth; i++)
            {
                for (int j = 0; j < ship.SizeHeigh; j++)
                {
                    if (ship[i, j].x != -1 && ship[i, j].x != 10
                            && ship[i, j].y != -1 && ship[i, j].y != 10
                                && _cells[ship[i, j].x, ship[i, j].y] is EmptyCell)
                    {
                        _cells[ship[i, j].x, ship[i, j].y] =
                            new MissCell(ship[i, j].x, ship[i, j].y);
                    }
                }
            }
        }
    }
}