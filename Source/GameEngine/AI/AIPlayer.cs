﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class AIPlayer : IPlayer
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }
        public Piece[] Pieces { get; set; }

        public AIPlayer(Colors color)
        {
            Name = $"{color} AI";
            Color = color;
            Pieces = Setup.Pieces(color);
        }
    }

    
}
