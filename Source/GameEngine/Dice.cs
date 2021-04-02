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

        public static int RollDice()
        {
            Random rnd = new Random();
            Value = rnd.Next(1, 7);
            return Value;
        }
        public static void RuleSix()
        {
            if (Dice.Value == 6 && true)
            {
                //Move piece out of nest
                Console.WriteLine("Pick a piece to move out of nest");
                Console.ReadLine();
            }

            if (Dice.Value == 6 && false)
            {
                //Move other piece that is not in nest
                Console.WriteLine("Pick a piece to move");
                Console.ReadLine();
            }
        }
    }
}

