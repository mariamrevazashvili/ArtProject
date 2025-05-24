using ArtProject.DTOs.Art;
using ArtProject.Models;
namespace ArtProject.IServices
{
    public interface IArtService
    {
        Task<IEnumerable<Art>> GetAllArtsUnderPriceAsync(int price);
        Task<IEnumerable<Art>> GetArtsInPriceRangeAsync(int minPrice, int maxPrice);
        Task<int> CreateartAsync(ArtCreateDto dto);
        void UpdateArt(ArtUpdateDto dto);
    }
}
