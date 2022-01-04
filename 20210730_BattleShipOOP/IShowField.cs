﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210730_BattleShipOOP
{
    interface IShowField
    {
        int SizeField { get; }

        IReadOnlyDictionary<Coordinate, Cell> Cells { get; }
    }
}
