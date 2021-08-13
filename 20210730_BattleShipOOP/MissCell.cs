using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class MissCell : Cell
    {
        public MissCell(int x, int y)
            : base(x, y)
        {
            _coordinate1.state = StateCell.Miss;
        }
    }
}