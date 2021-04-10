using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class Position
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Compare(Position position)
        {
            if (this.X == position.X && this.Y == position.Y)
                return true;

            else return false;
        }
    }
}
