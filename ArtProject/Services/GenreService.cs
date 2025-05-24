using ArtProject.Database;
using ArtProject.IServices;
using ArtProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtProject.Services
{
    public class GenreService : IGenreService
    {
        private readonly ArtDbContext _context;

        public GenreService(ArtDbContext context)
        {
            _context = context;
        }

        public async Task<List<Art>> GetArtByGenreAsync(string genre)
        {
            return await _context.Arts
                .Include(b => b.Genre)
                .Where(b => b.Genre.Janri == genre)
                .ToListAsync();
        }
    }
}
