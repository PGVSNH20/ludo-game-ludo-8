using Microsoft.EntityFrameworkCore;

namespace LudoGame.Database
{
    public class LudoDbContext : DbContext
    {
        public DbSet<Board> Board { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Piece> Piece { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=C:/Users/frejb/source/repos/ludo-game-ludo-8/Source/LudoGame/LudoDB.db");
    }
}    