using ArtProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ArtProject.DTOs.Art
{
    public class ArtCreateDto
    {
        [Required(ErrorMessage = "ArtName is required")]
        public string ArtName { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1000000, ErrorMessage = "Price must be between 1 and 1000000")]
        public int Price { get; set; }

        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }
}
