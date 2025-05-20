using ArtProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtProject.Database
{
    public class ArtDbContext : DbContext
    {
        public ArtDbContext(DbContextOptions<ArtDbContext> options) : base(options) { }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
