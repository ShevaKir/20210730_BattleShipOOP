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

        public override bool SetShip(ParametrShip ship)
        {
            bool freePlace = _userField.IsFreePlace(ship);

            if (freePlace)
            {
                _userField.AddShip(ship);
            }

            return freePlace;
        }

        public override bool SetShot(Coordinate shot)
        {
            bool free = _enemyField.IsFreeCell(shot);

            if (free)
            {
                _enemyField.AddShot(shot);
            }

            return free;
        }
    }
}