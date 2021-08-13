using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Cell
    {
        protected Coordinate _coordinate1;
        
        public Cell(int x, int y)
        {
            _coordinate1.x = x;
            _coordinate1.y = y;
        }

        public Coordinate Coordinate1
        {
            get
            {
                return _coordinate1;
            }
        }

        public void SetState(StateCell state)
        {
            _coordinate1.state = state;
        }
    }
}