using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player : IPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public Player(string color)
        {
            Name = $"{color} Player";
            Color = color;
        }

        public Player(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
