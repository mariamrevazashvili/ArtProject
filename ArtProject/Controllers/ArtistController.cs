using ArtProject.IServices;
using ArtProject.Models;
using ArtProject.Repository;
using Microsoft.AspNetCore.Mvc;
namespace ArtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistRepository artistRepository, IArtistService artistService)
        {
            _artistRepository = artistRepository;
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return Ok(await _artistRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            await _artistRepository.AddAsync(artist);
            return CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }

            _artistRepository.Update(artist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(int id)
        {
            _artistRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("ArtByArtist")]
        public async Task<ActionResult<List<Art>>> GetArtByArtistr(string artistName)
        {
            var arts = await _artistService.GetArtByArtistNameAsync(artistName);

            if (arts == null || arts.Count == 0)
            {
                return NotFound($"No arts found for artist: {artistName}");
            }

            return Ok(arts);
        }
    }
}
