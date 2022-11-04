using Chessnovert.Data.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication.ExtendedProtection;

namespace Chessnovert.Data
{
    public class ChessDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; } = null!;

        public DbSet<Move> Moves { get; set; } = null!;

        public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasIndex(g => g.PlayerBlack);
                entity.HasIndex(g => g.PlayerWhite);
                entity.HasMany(g => g.Moves)
                    .WithOne(m => m.Game)
                    .HasForeignKey(m => m.GameId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Move>(entity =>
            {
                entity.HasIndex(m => m.GameId);
            });
        }

    }
}
