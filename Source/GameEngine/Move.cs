﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Move
    {
        public int PlayerID { get; set; }
        public string PieceID { get; set; }
        public int DiceValue { get; set; }
    }
}
