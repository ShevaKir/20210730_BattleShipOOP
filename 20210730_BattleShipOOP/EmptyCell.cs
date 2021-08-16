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
            _coordinate1.state = StateCell.Empty;
        }

        public override string ToString()
        {
            return String.Format("*");
        }
    }
}