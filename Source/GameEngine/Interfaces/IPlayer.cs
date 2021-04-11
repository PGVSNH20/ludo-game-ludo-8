using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public interface IPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }
        public Piece[] Pieces { get; set; }
        public int BoardID { get; set; }
        public void Thinking();
    }
}
