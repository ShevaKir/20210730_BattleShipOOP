﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210730_BattleShipOOP
{
    class RandomShip
    {
        public static Random random = new Random();

        public static ParametrShip GetRandomShip(int deckCount)
        {
            ParametrShip ship = new ParametrShip();

            ship.coordinate.x = random.Next(0, 10);
            ship.coordinate.y = random.Next(0, 10);
            if (random.Next(0, 2) == 1)
            {
                ship.orientation = true;
            }
            else
            {
                ship.orientation = false;
            }
            ship.countDeck = deckCount;

            return ship;
        }
    }
}
