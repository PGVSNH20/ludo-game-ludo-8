using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface IPlayer
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }
        public Piece[] Pieces { get; set; }
    }
}
