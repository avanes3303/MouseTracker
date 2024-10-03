using Microsoft.EntityFrameworkCore;

namespace MouseTracker.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<MouseMovement> MouseMovements { get; set; }
    }
}
