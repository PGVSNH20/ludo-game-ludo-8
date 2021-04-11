using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LudoGame
{
    public class AIPlayer : IPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }
        [NotMapped]
        public Piece[] Pieces { get; set; }
        public int BoardID { get; set; }

        public AIPlayer(Colors color)
        {
            Name = $"{color} AI";
            Color = color;
            Pieces = Setup.Pieces(color);
        }

        public void Thinking()
        {
            Random rnd = new Random();
            int thinking = rnd.Next(50, 1000);
            Thread.Sleep(thinking);
        }
    }

    
}
