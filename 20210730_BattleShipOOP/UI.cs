﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class UI
    {
        public static Random random = new Random();

        public static ParametrShip GetRandomShip(int deckCount)
        {
            ParametrShip ship = new ParametrShip();

            ship.coordinate.x = random.Next(0, 10);
            ship.coordinate.y = random.Next(0, 10);
            if (random.Next(0, 2) == 1)
            {
                ship.orientation = true;
            }
            else
            {
                ship.orientation = false;
            }
            ship.countDeck = deckCount;

            return ship;
        }

        public static void ShowField(GameField field)
        {
            for (int i = 0; i < field.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < field.Cells.GetLength(1); j++)
                {
                    if(field.Cells[i, j] != null)
                    {
                        Console.Write("{0} ", field.Cells[i, j]);
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        //public Coordinate GetCoordinate()
        //{
        //    ConsoleKey key = Console.ReadKey(true).Key;
        //    ParametrShip parametrShip = new ParametrShip();
        //    parametrShip.coordinate.x = 0;
        //    parametrShip.coordinate.y = 0;
        //    parametrShip.orientation = true;
        //    switch (key)
        //    {
        //        case ConsoleKey.UpArrow:
        //            break;
        //        case ConsoleKey.DownArrow:
        //            break;
        //        case ConsoleKey.LeftArrow:
        //            break;
        //        case ConsoleKey.RightArrow:
        //            break;
        //        case ConsoleKey.Spacebar:
        //            break;
        //        default:
        //    }
        //}
    }
}