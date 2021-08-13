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

        public bool IsFreePlace(int x, int y, int countShip, bool orientation)
        {
            bool result = false;

            if (orientation)
            {
                if(x + countShip < SIZE)
                {
                    for (int i = x; i < x + countShip; i++)
                    {
                        if (_cells[i, y] == null)
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
                if(y + countShip < SIZE)
                {
                    for (int i = y; i < y + countShip; i++)
                    {
                        if (_cells[x, i] == null)
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

        public void AddShip()
        {

            //switch ()
            //{
            //    case 1:
                    
            //        _cells[ship.Coordinate1.x, ship.Coordinate1.y] = ship;
            //        break;
            //    case 2:
            //        _cells[ship.Coordinate1.x, ship.Coordinate1.y] = ship;
            //        _cells[ship.Coordinate2.x, ship.Coordinate2.y] = ship;
            //        break;
            //    case 3:
            //        _cells[ship.Coordinate1.x, ship.Coordinate1.y] = ship;
            //        _cells[ship.Coordinate2.x, ship.Coordinate2.y] = ship;
            //        _cells[ship.Coordinate3.x, ship.Coordinate3.y] = ship;

            //        break;
            //    case 4:
            //        _cells[ship.Coordinate1.x, ship.Coordinate1.y] = ship;
            //        _cells[ship.Coordinate2.x, ship.Coordinate2.y] = ship;
            //        _cells[ship.Coordinate3.x, ship.Coordinate3.y] = ship;
            //        _cells[ship.Coordinate4.x, ship.Coordinate4.y] = ship;
            //        break;
            //    default:
            //        break;
            //}
        }

    }
}