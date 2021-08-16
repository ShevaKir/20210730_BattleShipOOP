using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Game
    {
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
            _bot.SetShip(1);
            UI.ShowField(_userField);
        }


    }
}