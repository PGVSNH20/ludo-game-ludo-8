using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Database
{
    public class DbFunctions
    {
        ApplicationDbContext context = new ApplicationDbContext();


        public void SaveGame(Board BoardID, List<Move> Moves, List<IPlayer> Players, DateTime GameStarted)
        {

        }

    }
}
