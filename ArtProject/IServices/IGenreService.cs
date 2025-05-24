using ArtProject.Models;

namespace ArtProject.IServices
{
    public interface IGenreService
    {
        Task<List<Art>> GetArtByGenreAsync(string genre);
    }
}
