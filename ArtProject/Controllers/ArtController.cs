using ArtProject.DTOs.Art;
using ArtProject.IServices;
using ArtProject.Models;
using ArtProject.Repository;
using Microsoft.AspNetCore.Mvc;
namespace ArtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtsController : ControllerBase
    {
        private readonly IArtService _artService;
        private readonly IArtRepository _artRepository;

        public ArtsController(IArtService artService, IArtRepository artRepository)
        {
            _artService = artService;
            _artRepository = artRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Art>>> GetArts()
        {
            return Ok(await _artRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Art>> GetArt(int id)
        {
            var art = await _artRepository.GetByIdAsync(id);
            if (art == null)
            {
                return NotFound();
            }
            return Ok(art);
        }

        [HttpPost]
        public async Task<ActionResult<Art>> PostArt(ArtCreateDto artDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int newArtId = await _artService.CreateartAsync(artDto);
            return CreatedAtAction("GetArt", new { id = newArtId }, artDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArt(int id, ArtUpdateDto artDto)
        {
            if (id != artDto.Id)
            {
                return BadRequest();
            }

            _artService.UpdateArt(artDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArt(int id)
        {
            _artRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("by-artist")]
        public async Task<ActionResult<IEnumerable<Art>>> GetArtsByArtistName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Artist name cannot be empty.");

            var arts = await _artService.GetArtsByArtistNameAsync(name);
            return Ok(arts);
        }

        [HttpGet("bylocation/{location}")]
        public async Task<ActionResult<IEnumerable<Art>>> GetArtsByLocation(string location)
        {
            var arts = await _artService.GetArtsByLocationAsync(location);

            if (!arts.Any())
            {
                return NotFound($"No arts found in location: {location}");
            }

            return Ok(arts);
        }


        [HttpGet("underprice/{price}")]
        public async Task<ActionResult<IEnumerable<Art>>> GetArtsUnderPrice(int price)
        {
            var arts = await _artService.GetAllArtsUnderPriceAsync(price);
            return Ok(arts);
        }


        [HttpGet("aboveprice/{price}")]
        public async Task<ActionResult<IEnumerable<Art>>> GetArtsAbovePrice(int price)
        {
            var arts = await _artService.GetAllArtsAbovePriceAsync(price);
            return Ok(arts);
        }


        [HttpGet("price-range")]
        public async Task<ActionResult<IEnumerable<Art>>> GetArtsByPriceRange(int minPrice, int maxPrice)
        {
            if (minPrice > maxPrice)
                return BadRequest("Minimum price cannot be greater than maximum price.");

            var arts = await _artService.GetArtsInPriceRangeAsync(minPrice, maxPrice);
            return Ok(arts);
        }

        [HttpGet("average-price")]
        public async Task<ActionResult<double>> GetAverageArtPrice()
        {
            var averagePrice = await _artService.GetAverageArtPriceAsync();
            return Ok(averagePrice);
        }

    }
}
