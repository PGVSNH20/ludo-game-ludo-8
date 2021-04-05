using Microsoft.EntityFrameworkCore;


namespace GameEngine
{
    class DBModel : DbContext
    {
        public DBModel(): base()
            {

            }

        public DbSet<Player> Players { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=./LudoDB.db");
        }
    }
}
 