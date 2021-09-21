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
        protected ParametrShip _ship;
        protected Coordinate _shot;

        public abstract void SetShip(int deckCount);

        public abstract Coordinate GetShot(); 
    }
}