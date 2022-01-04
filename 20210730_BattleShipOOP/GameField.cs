using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class GameField : IShowField
    {
        private const int SHIP_COUNT = 10;
        private const int SIZE = 10;
        private int _countShip;
        private ShipCounting _countShipKilling;
        private Dictionary<Coordinate, Cell> _cells;

        public GameField()
        {
            _cells = new Dictionary<Coordinate, Cell>(SHIP_COUNT + 10);
        }

        public IReadOnlyDictionary<Coordinate, Cell> Cells
        {
            get
            {
                return _cells;
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
                return SHIP_COUNT;
            }
        }

        public int ShipOnTheField
        {
            get
            {
                return _countShip;
            }
        }

        

        public event ShipCounting CountKillShip
        {
            add
            {
                _countShipKilling += value;
            }
            remove
            {
                _countShipKilling -= value;
            }
        }

        private bool IsNotOutField(ParametrShip ship)
        {
            bool result = false;

            LinkedList<Coordinate> coordinates = ship.GetCoordinates();

            if (coordinates.First.Value.x >= 0 && coordinates.First.Value.y >= 0
                    && coordinates.Last.Value.x < SIZE && coordinates.Last.Value.y < SIZE)
            {
                result = true;
            }

            return result;
        }

        private bool IsNotOutField(Coordinate coordinate)
        {
            return coordinate.x >= 0 && coordinate.y >= 0
                    && coordinate.x < SIZE && coordinate.y < SIZE;
        }

        public bool IsFreePlace(ParametrShip ship)
        {
            bool result = false;

            if (IsNotOutField(ship))
            {
                foreach (Coordinate item in ship.GetCoordinates())
                {
                    if (!_cells.ContainsKey(item))
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

            return result;
        }

        public bool IsFreeCell(Coordinate coordinate)
        {
            bool result = false;

            if (IsNotOutField(coordinate))
            {
                if (_cells.ContainsKey(coordinate))
                {
                    if (!(_cells[coordinate] is MissCell) && !(_cells[coordinate] is HitCell))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = true;
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

                    singleShip.FillAroundShip();

                    _cells.Add(singleShip.Coordinate1, singleShip);

                    SetShipToField(singleShip);
                    _countShip++;
                    break;
                case 2:
                    DoubleDeckShip doubleShip = new DoubleDeckShip(sourceShip.coordinate.x, 
                            sourceShip.coordinate.y, sourceShip.orientation);

                    doubleShip.FillAroundShip();

                    _cells.Add(doubleShip.Coordinate1, doubleShip);
                    _cells.Add(doubleShip.Coordinate2, doubleShip);

                    SetShipToField(doubleShip);
                    _countShip++;
                    break;
                case 3:
                    ThreeDeckShip threeShip = new ThreeDeckShip(sourceShip.coordinate.x,
                            sourceShip.coordinate.y, sourceShip.orientation);

                    threeShip.FillAroundShip();

                    _cells.Add(threeShip.Coordinate1, threeShip);
                    _cells.Add(threeShip.Coordinate2, threeShip);
                    _cells.Add(threeShip.Coordinate3, threeShip);

                    SetShipToField(threeShip);
                    _countShip++;
                    break;
                case 4:
                    FourDeckShip fourShip = new FourDeckShip(sourceShip.coordinate.x,
                            sourceShip.coordinate.y, sourceShip.orientation);

                    fourShip.FillAroundShip();

                    _cells.Add(fourShip.Coordinate1, fourShip);
                    _cells.Add(fourShip.Coordinate2, fourShip);
                    _cells.Add(fourShip.Coordinate3, fourShip);
                    _cells.Add(fourShip.Coordinate4, fourShip);

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
                    if (ship[i, j].x != -1 && ship[i, j].x != SIZE
                            && ship[i, j].y != -1 && ship[i, j].y != SIZE)
                    {
                        if (!_cells.ContainsKey(ship[i, j]))
                        {
                            _cells.Add(ship[i, j], 
                                    new EmptyCell(ship[i, j].x, ship[i, j].y));
                        }
                    }
                    
                }
            }
        }


        public void AddShot(Coordinate shot)
        {
            if (_cells.ContainsKey(shot))
            {
                if (_cells[shot] is Ship ship)
                {
                    ship.SetDamage(shot.x, shot.y);
                    _cells[shot] = new HitCell(shot.x, shot.y);
                    if (ship.IsAllDamageDeck())
                    {
                        KillShip(ship);
                        _countShip--;
                    }
                }
                else
                {
                    _cells[shot] = new MissCell(shot.x, shot.y);
                }
            }
            else
            {
                _cells.Add(shot, new MissCell(shot.x, shot.y));
            }                  
        }

        public void KillShip(Ship ship)
        {
            if(_countShipKilling != null)
            {
                _countShipKilling(this, new ShipKillingEventArgs(SHIP_COUNT - _countShip + 1));
            }

            for (int i = 0; i < ship.SizeWidth; i++)
            {
                for (int j = 0; j < ship.SizeHeigh; j++)
                {
                    if (_cells.ContainsKey(ship[i, j]))
                    {
                        _cells[ship[i, j]] = new MissCell(ship[i, j].x, ship[i, j].y);
                    }
                }
            }
        }
    }
}