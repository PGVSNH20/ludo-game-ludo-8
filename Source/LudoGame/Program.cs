using GameEngine;
using System;

namespace LudoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            do {
                Console.WriteLine("1. Start new game");
                Console.WriteLine("2. Resume ongoing game");
                Console.WriteLine("3. Load game history");
                Console.WriteLine("0. Exit program");
                Console.Write("\nEnter your choice :\t");
                Console.ReadLine();
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
