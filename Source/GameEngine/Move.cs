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
    
        public Move(int playerId, int pieceId, int diceValue)
        {
            PlayerID = playerId;
            PieceID = pieceId;
            DiceValue = diceValue;
        }
    }
}
