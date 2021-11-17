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
        private bool _completed;
        private ParametrShip _ship;
        private Coordinate _shot;

        public Game()
        {
            _userField = new GameField();
            _botField = new GameField();

            _player = new User(_userField, _botField);
            _bot = new Bot(_botField, _userField);
        }
        
        public void Run()
        {
            AddAllShipOnField();

            _botField.CountKillShip += UI.CounterKillShip;

            Firefight();

            if (_userField.ShipOnTheField == 0)
            {
                UI.Victory(_bot);
            }

            if (_botField.ShipOnTheField == 0)
            {
                UI.Victory(_player);
            }

        }

        private void Firefight()
        {
            do
            {
                do
                {
                    UI.GetCoordinateShot(ref _shot);
                    try
                    {
                        _completed = _player.SetShot(_shot);
                    }
                    catch (OutOfFieldException ex)
                    {

                        UI.OutOfField(ex);
                    }
                    
                } while (!_completed);

                do
                {
                    Coordinate shot = RandomParametr.GetRandomShot();
                    _completed = _bot.SetShot(shot);
                } while (!_completed);

                UI.ShowField(_userField, 0, 0);
                UI.ShowField(_botField, 60, 0);

            } while (_userField.ShipOnTheField > 0 && _botField.ShipOnTheField > 0);
        }

        private void AddAllShipOnField()
        {
            do
            {
                do
                {
                    UI.GetCoordinate(GetDeck(_userField.ShipOnTheField), ref _ship);
                    _completed = _player.SetShip(_ship);
                } while (!_completed);

                do
                {
                    ParametrShip ship = RandomParametr.GetRandomShip(GetDeck(_botField.ShipOnTheField));
                    _completed = _bot.SetShip(ship);
                } while (!_completed);

                UI.ShowField(_userField, 0, 0);
                UI.ShowField(_botField, 60, 0);

            } while (_userField.ShipOnTheField < _userField.CountShip);
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