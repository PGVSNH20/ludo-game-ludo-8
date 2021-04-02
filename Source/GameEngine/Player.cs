using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool AI { get; set; }

        public Player(string color, bool ai)
        {
            if (ai == true)
                Name = $"{color} AI";
            else
                Name = $"{color} Player";

            Color = color;
            AI = ai;
        }

        public Player(string name, string color, bool ai)
        {
            Name = name;
            Color = color;
            AI = ai;
        }
    }
}
