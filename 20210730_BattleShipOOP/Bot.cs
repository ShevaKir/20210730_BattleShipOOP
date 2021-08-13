using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Bot : Player
    {
        public Bot(GameField userField, GameField enemyField)
        {
            _userField = userField;
            _enemyField = enemyField;
        }

        public override ParametrShip GetShip(int deckCount, int x, int y, bool orientation)
        {
            throw new NotImplementedException();
        }

        public override Coordinate GetShot()
        {
            throw new NotImplementedException();
        }
    }
}