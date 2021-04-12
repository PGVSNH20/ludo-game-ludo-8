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
                var players = new List<Player>();
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
                                var newPlayer = new Player(name, colorType, false);
                                players.Add(newPlayer);
                                Console.Clear();
                                Console.WriteLine($"Adding new {newPlayer.Name}({currentColor})...");
                                break;
                            case 2:
                                Console.Write("Enter player name: ");
                                name = Console.ReadLine();
                                players.Add(new Player(name, colorType, true));
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

                using var context = new LudoDbContext();
                var game = new Board(players, moves, DateTime.Now);
                context.Board.Add(game);
                context.SaveChanges();

                foreach (var player in players)
                {
                    player.BoardID = game.ID;
                    context.Player.Add(player);
                }
                context.SaveChanges();
                RenderGame(game);
            }
            public static void ResumeGame()
            {
                using var context = new LudoDbContext();
                if (context.Board.Where(g => g.ID >= 0).Any()) { 
                    var game = context.Board.Where(g => g.ID >= 0).OrderBy(i => i.ID).Last();
                    var players = context.Player.Where(p => p.BoardID == game.ID).ToList();
                    var moves = context.Move.Where(m => m.BoardID == game.ID).ToList();
                    Console.WriteLine($"Resuming game({game.ID})...");
                    foreach(var player in players)
                    {
                        player.Pieces = Setup.Pieces(player.Color);
                    }

                    foreach(var move in moves)
                    {
                        move.Player = players.Where(p => p.ID == move.PlayerID).Single();
                    }

                    game.Players = players;
                    game.Moves = moves;
                    Clear();
                    RenderGame(game);
                }
                else
                {
                    Console.WriteLine("Can't find any games in the database.");
                    Clear();
                }
            }

            public static void LoadGame()
            {
                bool isRunning = true;
                do
                {
                    using var context = new LudoDbContext();
                    var gameOptions = context.Board.Where(g => g.GameEnded == null).ToList();
                    foreach (var gameOption in gameOptions)
                    {
                        Console.WriteLine($"{gameOption.ID}. {gameOption.GameStarted}");
                    }
                    Console.Write("\nEnter the Game ID you would like to start :\t");
                    var userInput = Console.ReadLine();
                    var success = Int32.TryParse(userInput, out int result);

                    if (success && context.Board.Where(g => g.ID == result).Any())
                    {
                        var game = context.Board.Where(g => g.ID == result).Single();
                        var players = context.Player.Where(p => p.BoardID == game.ID).ToList();
                        var moves = context.Move.Where(m => m.BoardID == game.ID).ToList();

                        foreach (var player in players)
                        {
                            player.Pieces = Setup.Pieces(player.Color);
                        }

                        foreach (var move in moves)
                        {
                            move.Player = players.Where(p => p.ID == move.PlayerID).Single();
                        }

                        game.Players = players;
                        game.Moves = moves;
                        RenderGame(game);

                        isRunning = false;
                    }

                    else if (success)
                    {
                        Console.WriteLine("Couldn't find the game you're looking for.");
                    }

                    else
                    {
                        Console.WriteLine("Couldn't parse the value you entered.");
                    }

                    Console.Clear();
                } while (isRunning);
            }

            public static void RenderGame(Board game)
            {
                foreach (var move in game.Moves)
                {
                    Dice.Value = move.DiceValue;
                    game.MovePiece(move);
                }

                Clear();

                bool gameRunning = true;

                do
                {
                    foreach (var player in game.Players)
                    {   
                        bool fool = false;
                        game.PrintLudoBoard();
                        int pieceId = 1;
                        Setup.StringColor(player.Color);

                        if (player.AI == false)
                        {
                            Console.WriteLine($"It's {player.Name} turn. Press any key to roll dice!");
                            Clear();
                            Dice.Roll();
                            bool success = false;
                            do
                            {
                                game.PrintLudoBoard();
                                Setup.StringColor(player.Color);
                                Console.Write($"{player.Name} rolled a {Dice.Value}.");

                                if (!player.Pieces[0].AbleToMakeMove() && !player.Pieces[1].AbleToMakeMove() && !player.Pieces[2].AbleToMakeMove() && !player.Pieces[3].AbleToMakeMove())
                                {
                                    Console.WriteLine(" You can't move any piece.");
                                    fool = true;
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

                        else if (player.AI == true)
                        {
                            Console.WriteLine($"It's {player.Name} turn. Rolling the dice");
                            player.Thinking();
                            Console.Clear();
                            Dice.Roll();
                            game.PrintLudoBoard();
                            Setup.StringColor(player.Color);
                            if (!player.Pieces[0].AbleToMakeMove() && !player.Pieces[1].AbleToMakeMove() && !player.Pieces[2].AbleToMakeMove() && !player.Pieces[3].AbleToMakeMove())
                            {
                                fool = true;
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

                        if (!fool)
                        {
                            Move currentMove = new Move(player, pieceId, Dice.Value, player.ID, game.ID);
                            game.MovePiece(currentMove);
                            game.Moves.Add(currentMove);

                            using var movecontext = new LudoDbContext();
                            movecontext.Move.Add(currentMove);
                            movecontext.SaveChanges();
                        }

                        Console.Clear();

                        if (game.Ended(player))
                        {
                            game.GameEnded = DateTime.Now;
                            gameRunning = false;
                            game.PrintLudoBoard();
                            Setup.StringColor(player.Color);
                            Console.WriteLine($"{player.Name} won!\n");

                            foreach (var newPlayer1337 in game.Players)
                            {
                                for (int hej = 0; hej < newPlayer1337.Pieces.Length; hej++)
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