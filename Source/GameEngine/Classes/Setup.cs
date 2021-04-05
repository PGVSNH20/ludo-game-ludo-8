using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Setup
    {
        public static Piece[] Pieces(Colors color)
        {
            var pieces = new Piece[4];
            if (color == Colors.Red)
            {
                var RedStartPosition = new Position(1, 5);
                var RedEnterPosition = new Position(1, 6);
                pieces[0] = new Piece("R1", color, RedStartPosition, new Position(1, 1), RedEnterPosition);
                pieces[1] = new Piece("R2", color, RedStartPosition, new Position(2, 1), RedEnterPosition);
                pieces[2] = new Piece("R3", color, RedStartPosition, new Position(1, 2), RedEnterPosition);
                pieces[3] = new Piece("R4", color, RedStartPosition, new Position(2, 2), RedEnterPosition);
            }
            
            else if (color == Colors.Green)
            {
                var GreenStartPosition = new Position(7, 1);
                var GreenEnterPosition = new Position(6, 1);
                pieces[0] = new Piece("G1", color, GreenStartPosition, new Position(10, 1), GreenEnterPosition);
                pieces[1] = new Piece("G2", color, GreenStartPosition, new Position(11, 1), GreenEnterPosition);
                pieces[2] = new Piece("G3", color, GreenStartPosition, new Position(10, 2), GreenEnterPosition);
                pieces[3] = new Piece("G4", color, GreenStartPosition, new Position(11, 2), GreenEnterPosition);
            }

            else if (color == Colors.Blue)
            {
                var BlueStartPosition = new Position(5, 11);
                var BlueEnterPosition = new Position(6, 11);
                pieces[0] = new Piece("B1", Colors.Blue, BlueStartPosition, new Position(1, 10), BlueEnterPosition);
                pieces[1] = new Piece("B2", Colors.Blue, BlueStartPosition, new Position(2, 10), BlueEnterPosition);
                pieces[2] = new Piece("B3", Colors.Blue, BlueStartPosition, new Position(1, 11), BlueEnterPosition);
                pieces[3] = new Piece("B4", Colors.Blue, BlueStartPosition, new Position(2, 11), BlueEnterPosition);
            }

            else if (color == Colors.Yellow)
            {
                var YellowStartPosition = new Position(11, 7);
                var YellowEnterPosition = new Position(11, 6);
                pieces[0] = new Piece("Y1", Colors.Yellow, YellowStartPosition, new Position(10, 10), YellowEnterPosition);
                pieces[1] = new Piece("Y2", Colors.Yellow, YellowStartPosition, new Position(11, 10), YellowEnterPosition);
                pieces[2] = new Piece("Y3", Colors.Yellow, YellowStartPosition, new Position(10, 11), YellowEnterPosition);
                pieces[3] = new Piece("Y4", Colors.Yellow, YellowStartPosition, new Position(11, 11), YellowEnterPosition);
            }

            return pieces;
        }
    }
}
