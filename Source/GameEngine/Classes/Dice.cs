using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
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
        public static int Roll(int value)
        {
            if(value < 1)
            {
                Dice.Value = 1;
            }
            else if (value > 6)
            {
                Dice.Value = 6;
            }
            else
            {
                Dice.Value = value;
            }
            
            return Dice.Value;
        }
    }
}

