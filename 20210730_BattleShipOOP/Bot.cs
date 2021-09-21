using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Bot : Player, IWin
    {
        public string Win
        {
            get
            {
                return "Victory Bot";
            }
        }

        public Bot(GameField userField, GameField enemyField)
        {
            _userField = userField;
            _enemyField = enemyField;
        }

        public override void SetShip(int deckCount)
        {
            do
            {
                _ship = RandomParametr.GetRandomShip(deckCount);  
            } while (!_userField.IsFreePlace(_ship));
            _userField.AddShip(_ship);
        }

        public override Coordinate GetShot()
        {
            do
            {
                _shot = RandomParametr.GetRandomShot();
            } while (!_enemyField.IsFreeCell(_shot));

            return _shot;
        }
    }
}