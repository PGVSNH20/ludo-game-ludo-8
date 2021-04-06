using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public enum Colors { Red, Green, Blue, Yellow };

    public class Board
    {
        public List<Move> Moves { get; set; }
        public List<IPlayer> Players { get; set; }

        public Board(List<IPlayer> players)
        {
            Players = players;
        }

        public void PrintLudoBoard()
        {
            var allLines = File.ReadAllLines(@"..\..\..\ludo-board.txt");
            for(int y = 0; y < allLines.Length; y++)
            {
                string row = allLines[y];
                char[] column = row.ToCharArray();

                for(int x = 0; x < column.Length ; x++)
                {
                    bool playerPosition = false;

                    foreach(var player in this.Players)
                    {
                        for(int i = 0; i < player.Pieces.Length; i++)
                        {
                            if(y == player.Pieces[i].CurrentPosition.Y && x == player.Pieces[i].CurrentPosition.X)
                            {
                                if (player.Pieces[i].Color == Colors.Red)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }

                                else if (player.Pieces[i].Color == Colors.Green)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }

                                else if (player.Pieces[i].Color == Colors.Blue)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }

                                else if (player.Pieces[i].Color == Colors.Yellow)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }

                                Console.Write(player.Pieces[i].ID + " ");
                                playerPosition = true;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }

                    if (!playerPosition)
                    {
                        if (column[x] == ' ')
                        {
                            Console.Write("  ");
                        }

                        else if (column[x] == 'O')
                        {
                            Console.Write("O ");
                        }

                        else if (column[x] == '#')
                        {
                            Console.Write("# ");
                        }

                        else if (column[x] == '$')
                        {
                            Console.Write("$ ");
                        }
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
