using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public enum Colors { Red, Green, Blue, Yellow };

    public class Board
    {
        public List<Move> Moves { get; set; }
        public List<IPlayer> Players { get; set; }
    }
}
