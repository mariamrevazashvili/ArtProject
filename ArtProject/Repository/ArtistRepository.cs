using ArtProject.Database;
using ArtProject.Models;

namespace ArtProject.Repository
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ArtDbContext context) : base(context) { }

    }
}
