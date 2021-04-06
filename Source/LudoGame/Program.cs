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
        public class Game
        {
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
                var game = new Board();
                var players = new List<IPlayer>();

                for (int i=0; i < 4; i++)
                {
                    var currentColor = Enum.GetName(typeof(Colors), i);
                    Colors colorType = (Colors)Enum.Parse(typeof(Colors), currentColor);
                    Console.WriteLine("1. Add New Player");
                    Console.WriteLine("2. Add AI-Player");
                    Console.Write($"\n{currentColor} Player :\t");
                    var userInput = Console.ReadLine();
                    var success = Int32.TryParse(userInput, out int result);

                    if (success)
                    {
                        Console.Clear();
                        switch (result)
                        {
                            case 1:
                                Console.Write("Enter player name: ");
                                var name = Console.ReadLine();
                                var newPlayer = new Player(name, colorType);
                                players.Add(newPlayer);
                                Console.Clear();
                                Console.WriteLine($"Adding new {newPlayer.Name}({currentColor})...");
                                break;
                            case 2:
                                players.Add(new AIPlayer(colorType));
                                Console.Clear();
                                Console.WriteLine($"Adding new AI({currentColor})...");
                                break;
                            default:
                                Console.WriteLine("Couldn't find your value in the menu.");
                                i--;
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Couldn't parse the value you entered.");
                        i--;
                    }
                    Clear();
                }

                game.Players = players;
                
                foreach(var player in game.Players){
                    Console.WriteLine(player.Name);
                    Console.WriteLine(player.Pieces[3].Color);
                    Console.Write(player.Pieces[3].CurrentPosition.X);
                    Console.WriteLine(player.Pieces[3].CurrentPosition.Y);
                    Console.WriteLine();
                }

                Clear();
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