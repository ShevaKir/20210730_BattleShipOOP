using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210730_BattleShipOOP
{
    struct ParametrShip
    {
        public Coordinate coordinate;
        public OrientationShip orientation;
        public int countDeck;
        private LinkedList<Coordinate> _coordinates;

        public LinkedList<Coordinate> GetCoordinates()
        {
            if (_coordinates == null)
            {
                _coordinates = new LinkedList<Coordinate>();

                if (orientation == OrientationShip.Horizontal)
                {
                    for (int i = 0; i < countDeck; i++)
                    {
                        _coordinates.AddLast(new Coordinate() { x = coordinate.x + i, y = coordinate.y });
                    }
                }
                else
                {
                    for (int i = 0; i < countDeck; i++)
                    {
                        _coordinates.AddLast(new Coordinate() { x = coordinate.x, y = coordinate.y + i });
                    }
                }
            }

            return _coordinates;
        }

    }
}
