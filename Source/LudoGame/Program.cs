using LudoGame;
using LudoGame.Database;
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
                using var context = new LudoDbContext();

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
                using var context = new LudoDbContext();

                var players = new List<IPlayer>();
                var moves = new List<Move>();

                for (int i = 0; i < 4; i++)
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

                foreach (var player in players)
                {
                    context.Player.Add(player as Player);
                }
                context.SaveChanges();
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
                using var context = new LudoDbContext();
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

                        if (player.GetType() == typeof(Player))
                        {
                            Console.WriteLine($"It's {player.Name} turn. Press any key to roll dice!");
                            Clear();
                            Dice.Roll();
                            bool success = false;
                            do
                            {
                                game.PrintLudoBoard();
                                Console.Write($"{player.Name} rolled a {Dice.Value}.");

                                if (!player.Pieces[0].AbleToMakeMove() && !player.Pieces[1].AbleToMakeMove() && !player.Pieces[2].AbleToMakeMove() && !player.Pieces[3].AbleToMakeMove())
                                {
                                    Console.WriteLine("You can't move any piece.");
                                    success = true;
                                }

                                else
                                {
                                    Console.Write($" Which piece do you want to move? ");
                                    var playerInput = Console.ReadLine();
                                    success = Int32.TryParse(playerInput, out pieceId);

                                    if (success)
                                    {
                                        switch (pieceId)
                                        {
                                            case 1:
                                            case 2:
                                            case 3:
                                            case 4:
                                                if (player.Pieces[pieceId - 1].AbleToMakeMove())
                                                {
                                                    success = true;
                                                }
                                                else
                                                {
                                                    success = false;
                                                    Console.WriteLine("You're not able to move this piece. Try again...");
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("Wrong piece value. Try again...");
                                                success = false;
                                                break;
                                        }
                                    }
                                    else
                                        Console.WriteLine("Couldn't parse piece value. Try again...");
                                }

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
                            if (!player.Pieces[0].AbleToMakeMove() && !player.Pieces[1].AbleToMakeMove() && !player.Pieces[2].AbleToMakeMove() && !player.Pieces[3].AbleToMakeMove())
                            {
                                Console.WriteLine($"{player.Name} can't move any piece.");
                            }
                            else
                            {
                                Console.WriteLine($"{player.Name} rolled a {Dice.Value}. Choosing which piece to move ");
                                player.Thinking();
                                var rnd = new Random();
                                pieceId = rnd.Next(1, 5);

                                if (!player.Pieces[pieceId - 1].AbleToMakeMove())
                                {
                                    for (int i = 0; i < player.Pieces.Length; i++)
                                    {
                                        if (player.Pieces[i].AbleToMakeMove())
                                        {
                                            pieceId = i + 1;
                                        }
                                    }
                                }
                            }
                        }

                        Move currentMove = new Move(player, pieceId, Dice.Value);
                        game.MovePiece(currentMove);
                        game.Moves.Add(currentMove);
                        Console.Clear();

                        if (game.Ended(player))
                        {
                            gameRunning = false;
                            game.PrintLudoBoard();
                            Console.WriteLine($"{player.Name} won!\n");
                            foreach(var newPlayer1337 in players)
                            {
                                for(int hej = 0; hej < newPlayer1337.Pieces.Length; hej++)
                                {
                                    Console.WriteLine($"{newPlayer1337.Color}: {newPlayer1337.Pieces[hej].CurrentPosition.X}, {player.Pieces[hej].CurrentPosition.Y}");
                                }
                            }
                            Console.ReadKey();
                        } 
                    }
                } while (gameRunning);
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