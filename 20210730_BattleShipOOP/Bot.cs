using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Bot : Player
    {
        private int _countShip;
        private ParametrShip _ship;

        public Bot(GameField userField, GameField enemyField)
        {
            _userField = userField;
            _enemyField = enemyField;
        }

        public override void SetShip(int deckCount)
        {
            do
            {
                _ship = RandomShip.GetRandomShip(deckCount);  
            } while (!_enemyField.IsFreePlace(_ship));
            _enemyField.AddShip(_ship);
        }

        public override Coordinate GetShot()
        {
            throw new NotImplementedException();
        }
    }
}