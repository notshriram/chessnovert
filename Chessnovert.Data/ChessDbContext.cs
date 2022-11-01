using Microsoft.EntityFrameworkCore;

namespace Chessnovert.Data
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options) { }

    }
}
