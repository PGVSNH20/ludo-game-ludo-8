using Microsoft.EntityFrameworkCore;
using GameEngine;

namespace GameEngine
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Piece> Piece { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=./LudoDB.db");
        }
    }
}
