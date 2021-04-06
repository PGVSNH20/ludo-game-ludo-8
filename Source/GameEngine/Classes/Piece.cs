using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{

    public class Piece
    {
        public string ID { get; set; }
        public Colors Color { get; set; }
        public int Moves { get; set; } = 0;
        public Position CurrentPosition { get; set; }
        public Position StartPosition { get; set; }
        public Position NestPosition { get; set; }
        public Position EnterFinalTrackPosition { get; set; }
        public Position EndPosition = new Position(5,5);
        public int MoveDirectionX { get; set; }
        public int MoveDirectionY { get; set; }

        public Piece(string pieceID, Colors color, Position start, Position nest, Position enter)
        {
            ID = pieceID;
            Color = color;
            CurrentPosition = nest;
            StartPosition = start;
            NestPosition = nest;
            EnterFinalTrackPosition = enter;
        }
    }
}
