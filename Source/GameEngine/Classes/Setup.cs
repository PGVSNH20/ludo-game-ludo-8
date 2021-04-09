using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class Setup
    {
        public static Piece[] Pieces(Colors color)
        {
            var pieces = new Piece[4];
            if (color == Colors.Red)
            {
                var RedStartPosition = new Position(0, 4);
                var RedSixthPosition = new Position(4, 3);
                var RedEnterPosition = new Position(0, 5);
                pieces[0] = new Piece(1, color, new Position(0, 0), RedStartPosition, RedSixthPosition, new Position(0, 0), RedEnterPosition);
                pieces[1] = new Piece(2, color, new Position(1, 0), RedStartPosition, RedSixthPosition, new Position(1, 0), RedEnterPosition);
                pieces[2] = new Piece(3, color, new Position(0, 1), RedStartPosition, RedSixthPosition, new Position(0, 1), RedEnterPosition);
                pieces[3] = new Piece(4, color, new Position(1, 1), RedStartPosition, RedSixthPosition, new Position(1, 1), RedEnterPosition);
            }
            
            else if (color == Colors.Green)
            {
                var GreenStartPosition = new Position(6, 0);
                var GreenSixthPosition = new Position(7, 4);
                var GreenEnterPosition = new Position(5, 0);
                pieces[0] = new Piece(1, color, new Position(9, 0), GreenStartPosition, GreenSixthPosition, new Position(9, 0), GreenEnterPosition);
                pieces[1] = new Piece(2, color, new Position(10, 0), GreenStartPosition, GreenSixthPosition, new Position(10, 0), GreenEnterPosition);
                pieces[2] = new Piece(3, color, new Position(9, 1), GreenStartPosition, GreenSixthPosition, new Position(9, 1), GreenEnterPosition);
                pieces[3] = new Piece(4, color, new Position(10, 1), GreenStartPosition, GreenSixthPosition, new Position(10, 1), GreenEnterPosition);
            }
            
            else if (color == Colors.Yellow)
            {
                var YellowStartPosition = new Position(10, 6);
                var YellowSixthPosition = new Position(6, 7);
                var YellowEnterPosition = new Position(10, 5);
                pieces[0] = new Piece(1, Colors.Yellow, new Position(9, 9), YellowStartPosition, YellowSixthPosition, new Position(9, 9), YellowEnterPosition);
                pieces[1] = new Piece(2, Colors.Yellow, new Position(10, 9), YellowStartPosition, YellowSixthPosition, new Position(10, 9), YellowEnterPosition);
                pieces[2] = new Piece(3, Colors.Yellow, new Position(9, 10), YellowStartPosition, YellowSixthPosition, new Position(9, 10), YellowEnterPosition);
                pieces[3] = new Piece(4, Colors.Yellow, new Position(10, 10), YellowStartPosition, YellowSixthPosition, new Position(10, 10), YellowEnterPosition);
            }

            else if (color == Colors.Blue)
            {
                var BlueStartPosition = new Position(4, 10);
                var BlueSixthPosition = new Position(3, 6);
                var BlueEnterPosition = new Position(5, 10);
                pieces[0] = new Piece(1, Colors.Blue, new Position(0, 9), BlueStartPosition, BlueSixthPosition, new Position(0, 9), BlueEnterPosition);
                pieces[1] = new Piece(2, Colors.Blue, new Position(1, 9), BlueStartPosition, BlueSixthPosition, new Position(1, 9), BlueEnterPosition);
                pieces[2] = new Piece(3, Colors.Blue, new Position(0, 10), BlueStartPosition, BlueSixthPosition, new Position(0, 10), BlueEnterPosition);
                pieces[3] = new Piece(4, Colors.Blue, new Position(1, 10), BlueStartPosition, BlueSixthPosition, new Position(1, 10), BlueEnterPosition);
            }

            return pieces;
        }
    }
}
