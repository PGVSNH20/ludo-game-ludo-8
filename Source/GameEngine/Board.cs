using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{

    public enum BoardType { Nest, InPlay, Finish};

    public class Board
    {
        public List<Move> Moves { get; set; }
        public List<Player> PlayerID { get; set; }
    }
}
