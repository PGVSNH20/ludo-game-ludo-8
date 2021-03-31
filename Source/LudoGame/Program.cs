using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    public class Program
    {
        public static void Main(string[] args)
        {



            bool isRunning = true;
            do
            {
                var rollValue = Dice.RollDice();

                Console.WriteLine("1. Start new game");
                Console.WriteLine("2. Resume ongoing game");
                Console.WriteLine("3. Load game history");
                Console.WriteLine("0. Exit program");
                Console.Write("\nEnter your choice :\t");
                Console.ReadLine();


                Console.WriteLine("You roll the dice and get " + rollValue + " moves");



            } while (isRunning);
        }

        public static void StartGame()
        {

        }

        public static void ResumeGame()
        {

        }

        public static void LoadGame()
        {

        }

        public static void ExitGame()
        {

        }

        public static void RenderGame()
        {

        }
    }
}
