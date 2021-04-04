using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Setup
    {
        public enum Colors { Red, Green, Blue, Yellow };
        public static List<Piece> Pieces()
        {
            var RedStartPosition = new Position(1, 5);
            var RedEnterPosition = new Position(1, 6);
            var GreenStartPosition = new Position(7, 1);
            var GreenEnterPosition = new Position(6, 1);
            var BlueStartPosition = new Position(5, 11);
            var BlueEnterPosition = new Position(6, 11);
            var YellowStartPosition = new Position(11, 7);
            var YellowEnterPosition = new Position(11, 6);

            List<Piece> pieces = new List<Piece>
            {
                new Piece("R1", Colors.Red.ToString(), RedStartPosition, new Position(1, 1), RedEnterPosition),
                new Piece("R2", Colors.Red.ToString(), RedStartPosition, new Position(2, 1), RedEnterPosition),
                new Piece("R3", Colors.Red.ToString(), RedStartPosition, new Position(1, 2), RedEnterPosition),
                new Piece("R4", Colors.Red.ToString(), RedStartPosition, new Position(2, 2), RedEnterPosition),
                new Piece("G1", Colors.Green.ToString(), GreenStartPosition, new Position(10, 1), GreenEnterPosition),
                new Piece("G2", Colors.Green.ToString(), GreenStartPosition, new Position(11, 1), GreenEnterPosition),
                new Piece("G3", Colors.Green.ToString(), GreenStartPosition, new Position(10, 2), GreenEnterPosition),
                new Piece("G4", Colors.Green.ToString(), GreenStartPosition, new Position(11, 2), GreenEnterPosition),
                new Piece("B1", Colors.Blue.ToString(), BlueStartPosition, new Position(1, 10), BlueEnterPosition),
                new Piece("B2", Colors.Blue.ToString(), BlueStartPosition, new Position(2, 10), BlueEnterPosition),
                new Piece("B3", Colors.Blue.ToString(), BlueStartPosition, new Position(1, 11), BlueEnterPosition),
                new Piece("B4", Colors.Blue.ToString(), BlueStartPosition, new Position(2, 11), BlueEnterPosition),
                new Piece("Y1", Colors.Yellow.ToString(), YellowStartPosition, new Position(10, 10), YellowEnterPosition),
                new Piece("Y2", Colors.Yellow.ToString(), YellowStartPosition, new Position(11, 10), YellowEnterPosition),
                new Piece("Y3", Colors.Yellow.ToString(), YellowStartPosition, new Position(10, 11), YellowEnterPosition),
                new Piece("Y4", Colors.Yellow.ToString(), YellowStartPosition, new Position(11, 11), YellowEnterPosition)
            };

            return pieces;
        }
    }
}
