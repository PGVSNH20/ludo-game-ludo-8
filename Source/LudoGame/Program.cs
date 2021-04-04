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
        public enum Colors { Yellow, Blue, Red, Green };
        public class Game
        {
            public int playerAmount;
            public Player[] players;



            public static void Main(string[] args)
            {
                bool isRunning = true;
                do
                {
                    var userInput = PrintMenu();
                    var success = Int32.TryParse(userInput, out int result);
                    Console.Clear();

                    if (success)
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

            public void SetPlayerAmount()
            {
                Console.Write("How many players?: ");

                while (playerAmount < 2 || playerAmount > 4)
                {
                    if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.playerAmount))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid value, pick a number between 2 and 4");
                    }
                }
            }

            //private void CreatePlayers()
            //{
            //    this.players = new Player[this.playerAmount];

            //    for (int i = 0; i < this.playerAmount; i++)
            //    {
            //        Console.WriteLine();
            //        Console.Write("Name of player {0}: ", (i + 1));
            //        string name = Console.ReadLine();
            //        string id = ("#" + (i + 1));
            //        Colors clr = Colors.Red;

            //        switch (i)
            //        {
            //            case 0:
            //                clr = Colors.Red;
            //                break;
            //            case 1:
            //                clr = Colors.Blue;
            //                break;
            //            case 2:
            //                clr = Colors.Yellow;
            //                break;
            //            case 3:
            //                clr = Colors.Green;
            //                break;
            //        }
            //        this.players[i] = new Player(name);
            //    }
            //}

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

            public static string PrintMenu()
            {
                Console.WriteLine("1. Start new game");
                Console.WriteLine("2. Resume ongoing game");
                Console.WriteLine("3. Load game history");
                Console.WriteLine("0. Exit program");
                Console.Write("\nEnter your choice :\t");
                return Console.ReadLine();
            }

            public static void Clear()
            {
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}