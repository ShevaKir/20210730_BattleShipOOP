using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20210730_BattleShipOOP
{
    abstract class Ship : Cell, IView
    {
        protected Coordinate[,] _coordFullShip;

        public Ship(int x, int y)
            :base(x, y)
        {
        }

        public abstract void FillAroundShip();

        public abstract Coordinate this[int indexX, int indexY]
        {
            get;
        }

        public abstract int SizeWidth
        {
            get;
        }

        public abstract int SizeHeigh
        {
            get;
        }

        public GameObject ViewGameObject => GameObject.Ship;

        public abstract void SetDamage(int x, int y);

        public abstract bool IsAllDamageDeck();

        public override string ToString()
        {
            return String.Format("@");
        }

    }
}