using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210730_BattleShipOOP
{
    class ShipKillingEventArgs : EventArgs
    {
        private int _countShip;

        public ShipKillingEventArgs(int count)
        {
            _countShip = count;
        }

        public int KillingShip
        {
            get
            {
                return _countShip;
            }
        }
    }
}
