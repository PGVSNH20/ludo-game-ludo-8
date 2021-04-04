using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class LudoLogic
    {
        public static int RollDice()
        {
            Random rnd = new Random();
            Dice.Value = rnd.Next(1, 7);
            return Dice.Value;
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

            // diceValue ger steg,
            // pieceID är det som ska flyttas på Board
            // Detta ska loggas i Moves på något vis
            // Så att man håller koll på positionen av varje Piece
            public void MovePiece(int playerID, string pieceID, int diceValue, int posX, int posY)
            {
                Player
                Piece = pieceID;
                Dice.Value = diceValue;

            }

            // Om en piece står på samma moves som en annan piece så ska den knuffa ut motståndaren från brädet
            // Logik för vad som händer när man blir utknuffad behöver läggas till
            // Logik för vem som var först till ett move behöver loggas för att detta ska fungera rätvist :)
            public static void Push()
            {
                // lägg till lite lambda magic här
                if (Piece(Position(x, y)) == Piece(Position(x, y))
                {
                    //knuffa tillbaka motståndaren till sitt bo
                }

            }




        }
    }
