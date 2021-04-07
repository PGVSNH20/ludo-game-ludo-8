using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Move
    {
        public IPlayer Player { get; set; }
        public int PieceID { get; set; }
        public int DiceValue { get; set; }

        public Move(IPlayer player, int pieceId, int diceValue)
        {
            Player = player;
            PieceID = pieceId;
            DiceValue = diceValue;
        }
    }
}
