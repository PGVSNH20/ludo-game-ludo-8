using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Dice
    {
        private int Value { get; set; }

        public int Roll()
        {
            Random rnd = new Random();
            Value = rnd.Next(1, 7);
            return Value;
        }
    }
}
