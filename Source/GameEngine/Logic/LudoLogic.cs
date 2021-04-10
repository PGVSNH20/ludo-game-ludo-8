using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class LudoLogic
    {

        public static void DecideWhoStarts()
        {
            //Highest throw of the die starts.
        }


        public static void CantMove()
        {
            //If no piece can legally move according to the number thrown, play passes to the next player.
        }

        public static void ColorBlock()
        {
            //If a piece lands upon a piece of the same colour, this forms a block.
            //This block cannot be passed or landed on by any opposing piece.
        }

        public static void ExactThrow()
        {
            //When a piece has circumnavigated the board, it proceeds up the home column.
            //A piece can only be moved onto the home triangle by an exact throw.
            //The first person to move all 4 pieces into the home triangle wins.
        }

        public static void AnotherTurn()
        {
            //A throw of 6 gives another turn.
        }

        public static void WhenRollingSix()
        {
            bool isRunning = true;

            do
            {
                var userInput = Console.ReadLine();
                var success = Int32.TryParse(userInput, out int result);
                Console.Clear();


                if (Dice.Value == 6 || Dice.Value == 1)
                {
                    switch (result)
                    {
                        case 1:
                            MoveOutofNest();
                            break;

                        case 2:
                            MovePiece();
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Couldn't parse the value you entered.");
                }
                Console.Clear();

            } while (isRunning);
        }

        public static void MoveOutofNest()
        {
            Console.WriteLine("1: Pick a piece to move out of nest");
        }

        public static void MovePiece()
        {
            Console.WriteLine("2: Pick a piece to move");
        }
    }
}