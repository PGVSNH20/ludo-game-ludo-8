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
        public IPlayer Player { get; set; }

        public int ID { get; set; }
        public int PieceID { get; set; }
        public int DiceValue { get; set; }

        public Move()
        {
        }

        public Move(IPlayer player, int pieceId, int diceValue)
        {
            Player = player;
            PieceID = pieceId;
            DiceValue = diceValue;
        }
    }
}
