using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    abstract class Player
    {
        protected GameField _enemyField;
        protected GameField _userField;

        public abstract bool SetShip(ParametrShip ship);

        public abstract bool SetShot(Coordinate shot); 
    }
}