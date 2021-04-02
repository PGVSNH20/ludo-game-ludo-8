using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface IPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
