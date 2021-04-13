using LudoGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Event
    {
        public string Message { get; set; }
        public Colors Color { get; set; }

        public Event(string msg, Colors color)
        {
            Message = msg;
            Color = color;
        }
    }
}
