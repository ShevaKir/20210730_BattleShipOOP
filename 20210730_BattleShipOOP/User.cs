using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class User : Player
    {
        public User(GameField userField, GameField enemyField)
        {
            _userField = userField;
            _enemyField = enemyField;
        }

        public override void GetShip(int deckCount, int x, int y, bool orientation)
        {

            //if (_userField.IsFreePlace(x,y, deckCount, orientation))
            //{
            //    _userField.AddShip(ship);
            //}
            _userField.AddShip
            //return ship;
        }

        public void SetShip(ParametrShip ship)
        {
            ship = 
            
        }

        public override Coordinate GetShot()
        {
            return new Coordinate();
        }
    }
}