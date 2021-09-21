using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class EmptyCell : Cell
    {
        public EmptyCell(int x, int y)
            :base(x, y)
        {
        }

        public override Coordinate Coordinate1
        {
            get
            {
                return _coordinate1;
            }
        }
        

        public override string ToString()
        {
            return String.Format("*");
        }
    }
}