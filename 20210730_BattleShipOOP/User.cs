using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class User : Player, IWin
    {
        public string Win
        {
            get
            {
                return "Victory User";
            }
        }

        public User(GameField userField, GameField enemyField)
        {
            _userField = userField;
            _enemyField = enemyField;
        }

        public override void SetShip(int deckCount)
        {
            bool freePlace = false;
            do
            {
                _ship = UI.GetCoordinate(_ship, deckCount);
                try
                {
                    freePlace = _userField.IsFreePlace(_ship);
                    
                }
                catch(OutOfFieldException ex)
                {
                    UI.OutOfField(ex);
                }

            } while (!freePlace);

            _userField.AddShip(_ship);
            UI.WithinTheField();
        }


        public override Coordinate GetShot()
        {
            do
            {
                _shot = UI.GetCoordinateShot(_shot);
            } while (!_enemyField.IsFreeCell(_shot));

            return _shot;
        }
    }
}