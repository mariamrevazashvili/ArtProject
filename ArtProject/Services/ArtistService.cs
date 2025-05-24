using ArtProject.Database;
using ArtProject.IServices;
using ArtProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtProject.Services
{
    public class ArtistService : IArtistService
    {
        private readonly ArtDbContext _context;

        public ArtistService(ArtDbContext context)
        {
            _context = context;
        }

        public async Task<List<Art>> GetArtByArtistNameAsync(string artistName)
        {
            return await _context.Arts
                .Include(b => b.Artist)
                .Where(b => b.Artist.Name == artistName)
                .ToListAsync();
        }
    }
}
