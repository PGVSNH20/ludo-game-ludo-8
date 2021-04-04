using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Move
    {
        public int PlayerID { get; set; }
        public int PieceID { get; set; }
        public int DiceValue { get; set; }

        // Loggar move 1 move 2 move 3 osv... startar på 0
        public int Moves { get; set; } = 0;
    }
}
