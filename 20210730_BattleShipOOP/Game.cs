using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class Game
    {
        public Game()
        {
            GameField userField = new GameField();
            GameField botField = new GameField();

            User player = new User(userField, botField);
            Bot bot = new Bot(userField, botField);
        }

        public void Run()
        {
            
        }


    }
}