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

        public ArtService(ArtRepository artRepository)
        {
            _artRepository = artRepository;
        }

        public async Task<IEnumerable<Art>> GetAllArtsUnderPriceAsync(int price)
        {
            var arts = await _artRepository.GetAllAsync();
            return arts.Where(p => p.Price < price);
        }

        public void UpdateArt(ArtUpdateDto dto)
        {
            var art = _artRepository.GetByIdAsync(dto.Id).Result;
            if (art != null)
            {
                ArtMappingExtensions.UpdateDto(dto, art);
                _artRepository.Update(art);
                _artRepository.SaveChangesAsync();
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
