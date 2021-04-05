using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Dice
    {
        public static int Value { get; set; }

        public static int Roll()
        {
            Random rnd = new Random();
            Dice.Value = rnd.Next(1, 7);
            return Dice.Value;
        }
    }
}

