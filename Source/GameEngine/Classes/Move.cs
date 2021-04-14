using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class Move
    {
        [NotMapped]
        public Player Player { get; set; }
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int PieceID { get; set; }
        public int DiceValue { get; set; }

        public int BoardID { get; set; }

        public Move()
        {
        }

        public Move(Player player, int pieceId, int diceValue, int playerId, int boardId)
        {
            Player = player;
            PieceID = pieceId;
            DiceValue = diceValue;
            PlayerID = playerId;
            BoardID = boardId;
        }
    }
}
