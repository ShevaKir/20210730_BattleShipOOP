using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210730_BattleShipOOP
{
    class KillShipCounter
    {
        private int _count;

        public void DoIncrementKilling(object sender, EventArgs e)
        {
            _count++;
        }

        public void ResetCount(object sender, EventArgs e)
        {
            _count = 0;
        }
    }
}
