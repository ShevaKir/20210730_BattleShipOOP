using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Game
    {
        private const int SHIP_COUNT = 10;
        private User _player;
        private Bot _bot;
        private GameField _userField;
        private GameField _botField;

        public Game()
        {
            _userField = new GameField();
            _botField = new GameField();

            _player = new User(_userField, _botField);
            _bot = new Bot(_botField, _userField);
        }

        public void Run()
        {
            do
            {
                _player.SetShip(GetDeck(_userField.CountShip));
                _bot.SetShip(GetDeck(_botField.CountShip));
                UI.ShowField(_userField, 0, 0);
                UI.ShowField(_botField, 60, 0);
            } while (_userField.CountShip < SHIP_COUNT);

            do
            {
                _botField.SetShot(_player.GetShot());
                _userField.SetShot(_bot.GetShot());
                UI.ShowField(_userField, 0, 0);
                UI.ShowField(_botField, 60, 0);
            } while (_userField.CountShip > 0 && _botField.CountShip > 0);

            if (_userField.CountShip == 0)
            {
                UI.Victory(_bot);
            }

            if (_botField.CountShip == 0)
            {
                UI.Victory(_player);
            }

        }

        private int GetDeck(int countShip)
        {
            int deck = 0;

            if (countShip == 0)
            {
                deck = 4;
            }
            if(countShip == 1 || countShip == 2)
            {
                deck = 3;

            }
            if(countShip == 3 || countShip == 4 || countShip == 5)
            {
                deck = 2;
            }
            if(countShip >= 6)
            {
                deck = 1;
            }

            return deck;
        }
    }
}