using ArtProject.DTOs.Art;
using ArtProject.IServices;
using ArtProject.Mapper;
using ArtProject.Models;
using ArtProject.Repository;

namespace ArtProject.Services
{
    public class ArtService : IArtService
    {
        private readonly IArtRepository _artRepository;

        public ArtService(IArtRepository artRepository)
        {
            _artRepository = artRepository;
        }

        public async Task<IEnumerable<Art>> GetAllArtsUnderPriceAsync(int price)
        {
            var arts = await _artRepository.GetAllAsync();
            return arts.Where(p => p.Price < price);
        }

        public async Task<IEnumerable<Art>> GetAllArtsAbovePriceAsync(int price)
        {
            var arts = await _artRepository.GetAllAsync();
            return arts.Where(p => p.Price > price);
        }

        public async Task<IEnumerable<Art>> GetArtsByArtistNameAsync(string name)
        {
            var arts = await _artRepository.GetAllAsync();
            return arts.Where(a => a.Artist != null && a.Artist.Name.ToLower().Contains(name.ToLower()));
        }

        public async Task<IEnumerable<Art>> GetArtsByLocationAsync(string location)
        {
            var arts = await _artRepository.GetAllAsync();
            return arts.Where(a => a.Location.ToLower() == location.ToLower());
        }

        public async Task<double> GetAverageArtPriceAsync()
        {
            var arts = await _artRepository.GetAllAsync();

            if (!arts.Any())
                return 0;

            return arts.Average(a => a.Price);
        }

        public void UpdateArt(ArtUpdateDto dto)
        {
            var art = _artRepository.GetByIdAsync(dto.Id).Result;
            if (art != null)
            {
                ArtMappingExtensions.UpdateDto(dto, art);
                _artRepository.Update(art);
            }
        }

        public async Task<int> CreateartAsync(ArtCreateDto dto)
        {
            var art = dto.ToEntity();
            await _artRepository.AddAsync(art);
            return art.Id;
        }

        public async Task<IEnumerable<Art>> GetArtsInPriceRangeAsync(int minPrice, int maxPrice)
        {
            var arts = await _artRepository.GetAllAsync();
            return arts.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
        }
    }
}