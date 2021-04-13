using Microsoft.EntityFrameworkCore;

namespace LudoGame.Database
{
    public class LudoDbContext : DbContext
    {
        public DbSet<Board> Board { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Move> Move { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=C:/Users/frejb/source/repos/ludo-game-ludo-8/Source/LudoGame/LudoDB.db");
        
        // C:/Projects/Ludowreck8/Source/LudoGame/LudoDB.db
    }
}    