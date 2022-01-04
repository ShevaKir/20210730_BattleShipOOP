using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class MissCell : Cell, IView
    {
        public MissCell(int x, int y)
            : base(x, y)
        {
        }

        public override Coordinate Coordinate1
        {
            get
            {
                return _coordinate1;
            }
        }

        public GameObject ViewGameObject => GameObject.MissCell;

        public override string ToString()
        {
            return String.Format("Х");
        }
    }
}