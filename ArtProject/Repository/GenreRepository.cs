using ArtProject.Database;
using ArtProject.Models;

namespace ArtProject.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ArtDbContext context) : base(context) { }
    }
}
