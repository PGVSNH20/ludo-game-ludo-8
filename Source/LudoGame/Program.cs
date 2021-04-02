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
                Console.WriteLine("1. Start new game");
                Console.WriteLine("2. Resume ongoing game");
                Console.WriteLine("3. Load game history");
                Console.WriteLine("0. Exit program");
                Console.Write("\nEnter your choice :\t");
                var userInput = Console.ReadLine();
                var success = Int32.TryParse(userInput, out int result);
                Console.Clear();

                if(success)
                {
                    switch (result)
                    {
                        case 1:
                            StartGame();
                            break;
                        case 2:
                            ResumeGame();
                            break;
                        case 3:
                            LoadGame();
                            break;
                        case 0:
                            isRunning = false;
                            Console.WriteLine("Already quitting this ludo game? Press any key to exit... Bye!");
                            break;
                        default:
                            Console.WriteLine("Couldn't find your value in the menu.");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Couldn't parse the value you entered.");
                }
                Clear();
            } while (isRunning);
        }

        public static void StartGame()
        {
            Console.WriteLine("Starting game...");
        }

        public static void ResumeGame()
        {
            Console.WriteLine("Resuming game...");
        }

        public static void LoadGame()
        {
            Console.WriteLine("Loading game...");
        }

        public static void RenderGame()
        {

        }

        public static void Clear()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
