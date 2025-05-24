using ArtProject.Models;

namespace ArtProject.IServices
{
    public interface IArtistService
    {
        Task<List<Art>> GetArtByArtistNameAsync(string artistName);
    }
}
