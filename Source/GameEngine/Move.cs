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


        // diceValue ger steg,
        // pieceID är det som ska flyttas på Board
        // Detta ska loggas i Moves på något vis
        // Så att man håller koll på positionen av varje Piece
        public void MovePiece(int pieceID, int diceValue)
        {
            PieceID = pieceID;
            DiceValue = diceValue;  
        }

        // Om en piece står på samma moves som en annan piece så ska den knuffa ut motståndaren från brädet
        // Logik för vad som händer när man blir utknuffad behöver läggas till
        // Logik för vem som var först till ett move behöver loggas för att detta ska fungera rätvist :)
        public void Push(int pieceID, int moves)
        {
            PieceID = pieceID;
            Moves = moves;
        }
    }
}
