using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Bot : Player
    {
        private int _countShip;

        public Bot(GameField userField, GameField enemyField)
        {
            _userField = userField;
            _enemyField = enemyField;
        }

        public override void SetShip(int deckCount)
        {
            ParametrShip ship = UI.GetRandomShip(deckCount);
            
            if(_enemyField.IsFreePlace(ship))
            {
                _enemyField.AddShip(ship);
            }
        }

        public override Coordinate GetShot()
        {
            throw new NotImplementedException();
        }
    }
}