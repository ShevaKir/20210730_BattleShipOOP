using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    class UI
    {
        /*
         * ┌───┐┌───┐
         * │ a ││ a │ 
         * └───┘└───┘
         */
        private const char IMAGE_DECK = '■';
        private const char IMAGE_MISS = 'X';
        private const char IMAGE_HIT = '+';
        private const char IMAGE_EMPHY = ' ';
        private const int SHIFT_TOP = 2;
        private const int SHIFT_LEFT = 4;

        private static string[] _cell = new string[] 
        {
            "┼───┼",
            "│   │",
            "┼───┼"
        };
        /*" │ ",
        "─┼─",
        " │",─*/

        public static void ShowGrid(IShowField field, int left, int top)
        {
            for (int i = 0; i < field.SizeField; i++)
            {
                for (int j = 0; j < field.SizeField; j++)
                {
                    int strCount = 0;
                    while (strCount < _cell.Length)
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.Write(_cell[strCount++]);                
                    }
                    left += SHIFT_LEFT;
                    top -= SHIFT_TOP + 1;
                }
                left -= field.SizeField * SHIFT_LEFT;
                top += SHIFT_TOP;
            }
        }

        public static void ShowField(IShowField field, int left, int top)
        {
            int leftStart = 2;
            int topStart = 1;
            int shiftLeft = 4;
            int shiftTop = 2;

            foreach (KeyValuePair<Coordinate, Cell> item in field.Cells)
            {
                if (!(item.Value is EmptyCell))
                {
                    Console.SetCursorPosition(leftStart + item.Key.y * shiftLeft + left, 
                            topStart + item.Key.x * shiftTop + top);
                    Console.Write(item.Value);
                }
            }

        }

        public static char GetImage(Cell cell)
        {
            char image = IMAGE_EMPHY;

            if (cell is Ship)
            {
                image = IMAGE_DECK;
            }
            if (cell is MissCell)
            {
                image = IMAGE_MISS;
            }
            if (cell is HitCell)
            {
                image = IMAGE_HIT;
            }

            return image;
        }

        public static void Victory(IWin player)
        {
            Console.SetCursorPosition(0, 24);
            Console.WriteLine(player.Win);
        }

        public static void ShowParametr(ParametrShip parametrShip, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write("X = {0} , Y = {1} ", parametrShip.coordinate.x, parametrShip.coordinate.y);
            Console.SetCursorPosition(left, top + 1);
            Console.Write("Route: {0}        ", parametrShip.orientation);

        }

        public static void ShowCoordinate(Coordinate shot, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write("X = {0} , Y = {1} ", shot.x, shot.y);
        }

        public static void GetCoordinate(int deckShip, ref ParametrShip parametrShip)
        {
            parametrShip.countDeck = deckShip;

            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        parametrShip.coordinate.x--;
                        break;
                    case ConsoleKey.DownArrow:
                        parametrShip.coordinate.x++;
                        break;
                    case ConsoleKey.LeftArrow:
                        parametrShip.coordinate.y--;
                        break;
                    case ConsoleKey.RightArrow:
                        parametrShip.coordinate.y++;
                        break;
                    case ConsoleKey.Spacebar:
                        if (parametrShip.orientation == OrientationShip.Vertical)
                        {
                            parametrShip.orientation = OrientationShip.Horizontal;
                        }
                        else
                        {
                            parametrShip.orientation = OrientationShip.Vertical;
                        }
                        break;
                }

                ShowParametr(parametrShip, 0, 26);

            } while (key != ConsoleKey.Enter);
            
        }

        public static Coordinate GetCoordinateShot(ref Coordinate shot)
        {         
            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        shot.x--;
                        break;
                    case ConsoleKey.DownArrow:
                        shot.x++;
                        break;
                    case ConsoleKey.LeftArrow:
                        shot.y--;
                        break;
                    case ConsoleKey.RightArrow:
                        shot.y++;
                        break;
                }

                ShowCoordinate(shot, 0, 25);

            } while (key != ConsoleKey.Enter);

            return shot;
        }


        public static void OutOfField(OutOfFieldException ex)
        {
            Console.SetCursorPosition(0, 22);
            Console.Write("OutOfField: {0}", ex.StackTrace);
        }

        public static void WithinTheField()
        {
            Console.SetCursorPosition(0, 22);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Console.BufferWidth; j++)
                {
                    Console.Write(" ");
                }
            }   
        }

        public static void CounterKillShip(object sender, ShipKillingEventArgs e)
        {
            Console.SetCursorPosition(15, 27);
            Console.WriteLine("Kill ship: {0}", e.KillingShip);
        }
    }
}