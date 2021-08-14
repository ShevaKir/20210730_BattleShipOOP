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

        public Game()
        {
            GameField userField = new GameField();
            GameField botField = new GameField();

            _player = new User(userField, botField);
            _bot = new Bot(botField, userField);

        }

        public void Run()
        {
            _bot.SetShip(4);
        }


    }
}