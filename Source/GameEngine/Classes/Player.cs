using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player : IPlayer
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }
        public Piece[] Pieces { get; set; }

        public Player(Colors color)
        {
            Name = $"{color} Player";
            Color = color;
            Pieces = Setup.Pieces(color);
        }

        public Player(string name, Colors color)
        {
            Name = name;
            Color = color;
            Pieces = Setup.Pieces(color);
        }
    }
}
