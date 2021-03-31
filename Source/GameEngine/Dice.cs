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

            if (Value == 6)
            {
                LeaveNestMaybe();
            }

            else
            {
                return Value;
            }
        } 

        public void LeaveNestMaybe()
        {
            // Nån slags meny här om man vill lämna boet eller flytta en annan pjäs som redan är ute på brädet
        }



    }
}
