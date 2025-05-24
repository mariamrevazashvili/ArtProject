using ArtProject.DTOs.Art;
using ArtProject.Models;
namespace ArtProject.Mapper
{
    public static class ArtMappingExtensions
    {
        public static Art ToEntity(this ArtCreateDto dto)
        {
            return new Art
            {
                ArtName = dto.ArtName,
                Year = dto.Year,
                Location = dto.Location,
                Price = dto.Price,
                ArtistId = dto.ArtistId,
                GenreId = dto.GenreId
            };
        }

        public static void UpdateDto(ArtUpdateDto dto, Art art)
        {
            art.Price = dto.Price;
        }
    }
}
