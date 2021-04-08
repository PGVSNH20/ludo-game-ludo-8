using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                var players = new List<IPlayer>();
                var moves = new List<Move>();

                for (int i=0; i < 4; i++)
                {
                    var currentColor = Enum.GetName(typeof(Colors), i);
                    Colors colorType = (Colors)Enum.Parse(typeof(Colors), currentColor);
                    Console.WriteLine("1. Add New Player");
                    Console.WriteLine("2. Add AI-Player");
                    Console.Write($"\n{currentColor} Player :\t");
                    var userInput = Console.ReadLine();
                    var success = Int32.TryParse(userInput, out int result);
                    Console.Clear();

                    if (success)
                    {

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

                RenderGame(players, moves, DateTime.Now);
            }

            public static void ResumeGame()
            {
                Console.WriteLine("Resuming game...");
            }

            public static void LoadGame()
            {
                Console.WriteLine("Loading game...");
            }

            public static void RenderGame(List<IPlayer> players, List<Move> moves, DateTime gameStarted)
            {
                var game = new Board(players, moves, gameStarted);

                //Move move1 = new Move(1, "1", Dice.Roll());
                //game.MovePiece(move1);

                // foreach move-logik

                bool gameRunning = true;

                do
                {
                    foreach (var player in game.Players)
                    {
                        game.PrintLudoBoard();
                        int pieceId = 1;
                        if(player.GetType() == typeof(Player))
                        {
                            Console.WriteLine($"It's {player.Name} turn. Press any key to roll dice!");
                            Clear();
                            Dice.Roll();
                            bool success = false;
                            do
                            {
                                game.PrintLudoBoard();
                                Console.Write($"{player.Name} rolled a {Dice.Value}.");
                                Console.Write($" Which piece do you want to move? ");
                                var playerInput = Console.ReadLine();
                                success = Int32.TryParse(playerInput, out pieceId);
                                if (success)
                                {
                                    switch (pieceId)
                                    {
                                        case 1:
                                            break;
                                        case 2:
                                            break;
                                        case 3:
                                            break;
                                        case 4:
                                            break;
                                        default:
                                            Console.WriteLine("Wrong piece value.");
                                            success = false;
                                            break;
                                    }
                                }
                                else
                                    Console.WriteLine("Couldn't parse piece value.");

                                Clear();
                            } while (!success);
                        }

                        else if (player.GetType() == typeof(AIPlayer))
                        {
                            Console.WriteLine($"It's {player.Name} turn. Rolling the dice");
                            player.Thinking();
                            Console.Clear();
                            Dice.Roll();
                            game.PrintLudoBoard();
                            Console.Write($"{player.Name} rolled a {Dice.Value}. Choosing which piece to move ");
                            player.Thinking();
                            var rnd = new Random();
                            pieceId = rnd.Next(1, 5);
                        }

                        Move currentMove = new Move(player, pieceId, Dice.Value);
                        game.MovePiece(currentMove);
                        game.Moves.Add(currentMove);

                        if (game.Ended())
                            gameRunning = false;

                        Console.Clear();
                    }
                } while (gameRunning);

                game.PrintLudoBoard();
                Console.WriteLine("You won!");
                Clear();
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