using ArtProject.Database;
using ArtProject.Models;

namespace ArtProject.Repository
{
    public class ArtRepository: GenericRepository<Art>, IArtRepository
    {
        public ArtRepository(ArtDbContext context) : base(context) { }
    }
}
