﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public enum Colors { Red, Green, Yellow, Blue };

    public class Board
    {
        public int BoardID { get; set; }
        public List<Move> Moves { get; set; }
        public List<IPlayer> Players { get; set; }
        public DateTime GameStarted { get; set; }

        public Board(List<IPlayer> players, List<Move> moves, DateTime gameStarted)
        {
            Players = players;
            Moves = moves;
            GameStarted = gameStarted;
        }

        public bool Ended()
        {
            foreach (var player in this.Players)
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
                    return true;
            }
            return false;
        }

        public void MovePiece(Move move)
        {
            var id = move.PieceID - 1;
            for (int remainingMoves = move.DiceValue; remainingMoves > 0; remainingMoves--)
            {
                if (move.Player.Pieces[id].CurrentPosition.Compare(move.Player.Pieces[id].NestPosition) && Dice.Value == 1 || move.Player.Pieces[id].CurrentPosition.Compare(move.Player.Pieces[id].NestPosition) && Dice.Value == 6)
                {
                    move.Player.Pieces[id].MoveOut();
                    remainingMoves = 0;
                }
                else
                {
                    move.Player.Pieces[id].Moves++;
                    move.Player.Pieces[id].TrackMovement();
                }
            }

            if (move.Player.Pieces[id].PushOpponent(this.Players))
            {
                Console.WriteLine($"{move.Player.Name} pushed opponent into their nest!");
            }
        }

        public void PrintLudoBoard()
        {
            var allLines = File.ReadAllLines(@"..\..\..\ludo-board.txt");
            for (int y = 0; y < allLines.Length; y++)
            {
                string row = allLines[y];
                char[] column = row.ToCharArray();

                for (int x = 0; x < column.Length; x++)
                {
                    int piecesOnSpot = 0;
                    bool playerPosition = false;
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
                                        if (player.Pieces[i].Color == Colors.Red)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                        }

                                        else if (player.Pieces[i].Color == Colors.Green)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        }

                                        else if (player.Pieces[i].Color == Colors.Yellow)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        }

                                        else if (player.Pieces[i].Color == Colors.Blue)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                        }

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
                                            if (player.Color == Colors.Red)
                                                Console.ForegroundColor = ConsoleColor.Red;
                                            else if (player.Color == Colors.Green)
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            else if (player.Color == Colors.Yellow)
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            else if (player.Color == Colors.Blue)
                                                Console.ForegroundColor = ConsoleColor.Blue;
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
                                        if (player.Color == Colors.Red)
                                            Console.ForegroundColor = ConsoleColor.Red;
                                        else if (player.Color == Colors.Green)
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        else if (player.Color == Colors.Yellow)
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        else if (player.Color == Colors.Blue)
                                            Console.ForegroundColor = ConsoleColor.Blue;
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
            Console.WriteLine();
        }
    }
}
