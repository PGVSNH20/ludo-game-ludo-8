using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class Player : IPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }
        [NotMapped]
        public Piece[] Pieces { get; set; }

        public Player(string name, Colors color)
        {
            if (name == "")
                Name = $"{color} Player";
            else
                Name = name;

            Color = color;
            Pieces = Setup.Pieces(color);
        }

        public void Thinking()
        {
            throw new NotImplementedException(); // You can think for yourself...
        }
    }
}
