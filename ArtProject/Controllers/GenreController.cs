using ArtProject.IServices;
using ArtProject.Models;
using ArtProject.Repository;
using Microsoft.AspNetCore.Mvc;
namespace ArtProject.Controllers
{
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IGenreService _genreService;

        public GenresController(IGenreRepository genreRepository, IGenreService genreService)
        {
            _genreRepository = genreRepository;
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return Ok(await _genreRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            await _genreRepository.AddAsync(genre);
            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _genreRepository.Update(genre);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            _genreRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("ArtByGenre")]
        public async Task<ActionResult<List<Art>>> GetArtByGenre(string genre)
        {
            var arts = await _genreService.GetArtByGenreAsync(genre);

            if (arts == null || arts.Count == 0)
            {
                return NotFound($"No arts found for genre: {genre}");
            }

            return Ok(arts);
        }
    }
}
