using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    abstract class Cell
    {
        protected Coordinate _coordinate1;
        
        public Cell(int x, int y)
        {
            _coordinate1.x = x;
            _coordinate1.y = y;
        }

        abstract public Coordinate Coordinate1 { get; }
    }
}