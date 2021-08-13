using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    abstract class Ship : Cell
    {
        public Ship(int x, int y)
            :base(x, y)
        {
            _coordinate1.state = StateCell.Ship;
        }
    }
}