using GameEngine;
using GameEngine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LudoGame
{
    public enum Colors { Red, Green, Yellow, Blue };

    public class Board
    {
        [NotMapped]
        public List<Event> Events { get; set; }
        public int ID { get; set; }
        public List<Move> Moves { get; set; }
        [NotMapped]
        public List<Player> Players { get; set; }
        public DateTime GameStarted { get; set; }
        public DateTime? GameEnded { get; set; }

        public Board()
        {

        }

        public Board(List<Player> players, List<Move> moves, DateTime gameStarted)
        {
            Players = players;
            Moves = moves;
            GameStarted = gameStarted;
        }
        public bool Ended(Player player)
        {
            int piecesInEndPos = 0;
            for (int i = 0; i < player.Pieces.Count(); i++)
            {
                if (player.Pieces[i].CurrentPosition.Compare(player.Pieces[i].EndPosition))
                {
                    piecesInEndPos++;
                }
            }

            if (piecesInEndPos == 4)
            {
                return true;
            }

            return false;
        }

        public void MovePiece(Move move, bool fool)
        {
            var id = move.PieceID - 1;
            string message = $"Not made a move yet.";
            for (int remainingMoves = move.DiceValue; remainingMoves > 0; remainingMoves--)
            {
                if (move.Player.Pieces[id].CurrentPosition.Compare(move.Player.Pieces[id].NestPosition) && Dice.Value == 1 || move.Player.Pieces[id].CurrentPosition.Compare(move.Player.Pieces[id].NestPosition) && Dice.Value == 6)
                {
                    move.Player.Pieces[id].MoveOut();
                    remainingMoves = 0;
                    message = $"[@] {move.Player.Name} moved piece {move.PieceID} out of nest";
                }
                else
                {
                    move.Player.Pieces[id].Moves++;
                    move.Player.Pieces[id].TrackMovement();
                    message = $"[+] {move.Player.Name} rolled a {move.DiceValue} and moved piece {move.PieceID}.";

                    if (move.Player.Pieces[id].CurrentPosition.Compare(move.Player.Pieces[id].EnterFinalTrackPosition))
                    {
                        message = $"[+] A {move.DiceValue} was rolled and {move.Player.Name} entered the final track with piece {move.PieceID}.";
                    }
                }
            }
            
            if (this.Ended(move.Player))
            {
                message = $"[$] Congratulations, {move.Player.Name} won the game!";
            }

            else if (move.Player.Pieces[id].CurrentPosition.Compare(move.Player.Pieces[id].EndPosition))
            {
                message = $"[$] {move.Player.Name} has moved piece {move.PieceID} into goal but still got some pieces out on the board.";
            }

            Event moveEvent = new Event(message, move.Player.Color);
            this.Events.Add(moveEvent);

            Player opponent = move.Player.Pieces[move.PieceID - 1].PushOpponent(this.Players);

            if (opponent == null) { }

            else
            {
                message = $"[!] {opponent.Name} got pushed back into their nest by {move.Player.Name}!";
                Console.WriteLine(message);
                var pushEvent = new Event(message, opponent.Color);
                this.Events.Add(pushEvent);
                if (!fool)
                {
                    if (move.Player.AI == false)
                    {
                        Console.ReadKey();
                    }
                    else if (move.Player.AI == true)
                    {
                        Thread.Sleep(500);
                    }
                }

                Console.Clear();
            }
        }

        public void PrintLudoBoard()
        {
            if(this.Events != null)
            {
                foreach(var e in this.Events)
                {
                    Setup.StringColor(e.Color);
                    Console.WriteLine(e.Message);
                }
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("             _____________________\n");
            
            var allLines = File.ReadAllLines(@"..\..\..\ludo-board.txt");
            for (int y = 0; y < allLines.Length; y++)
            {
                string row = allLines[y];
                char[] column = row.ToCharArray();

                for (int x = 0; x < column.Length; x++)
                {
                    int piecesOnSpot = 0;
                    bool playerPosition = false;
                    if(x == 0)
                    {
                        Console.Write("             ");
                    }

                    if (column[x] == '$')
                    {
                        Console.Write("$ ");
                    }
                    else
                    {
                        foreach (var player in this.Players)
                        {
                            for (int i = 0; i < player.Pieces.Length; i++)
                            {
                                if (piecesOnSpot == 0)
                                {
                                    if (y == player.Pieces[i].CurrentPosition.Y && x == player.Pieces[i].CurrentPosition.X)
                                    {
                                        Setup.StringColor(player.Color);
                                        Console.Write(player.Pieces[i].ID + " ");
                                        playerPosition = true;
                                        piecesOnSpot++;
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                            }
                        }

                        if (!playerPosition)
                        {
                            if (column[x] == ' ')
                            {
                                Console.Write("  ");
                            }

                            else if (column[x] == 'X')
                            {
                                foreach (var player in this.Players)
                                {
                                    for (int i = 0; i < player.Pieces.Length; i++)
                                    {
                                        if (player.Pieces[i].NestPosition.Compare(new Position(x, y)))
                                        {
                                            Setup.StringColor(player.Color);
                                        }
                                    }
                                }
                                Console.Write("x ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (column[x] == 'O')
                            {
                                foreach (var player in this.Players)
                                {
                                    if (player.Pieces[0].StartPosition.Compare(new Position(x, y)) || player.Pieces[0].SixthPosition.Compare(new Position(x, y)))
                                    {
                                        Setup.StringColor(player.Color);
                                    }
                                }
                                Console.Write("O ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (column[x] == '#')
                            {
                                foreach (var player in this.Players)
                                {
                                    if (player.Color == Colors.Red)
                                    {
                                        if (player.Pieces[0].EnterFinalTrackPosition.X < x && x < player.Pieces[0].EndPosition.X)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                        }
                                    }

                                    else if (player.Color == Colors.Green)
                                    {
                                        if (player.Pieces[0].EnterFinalTrackPosition.Y < y && y < player.Pieces[0].EndPosition.Y)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        }
                                    }

                                    else if (player.Color == Colors.Yellow)
                                    {
                                        if (player.Pieces[0].EnterFinalTrackPosition.X > x && x > player.Pieces[0].EndPosition.X)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        }
                                    }

                                    else if (player.Color == Colors.Blue)
                                    {
                                        if (player.Pieces[0].EnterFinalTrackPosition.Y > y && y > player.Pieces[0].EndPosition.Y)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                        }
                                    }
                                }
                                Console.Write("# ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("             _____________________\n");
        }
    }
}
