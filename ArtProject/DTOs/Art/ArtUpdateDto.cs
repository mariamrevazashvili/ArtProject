using ArtProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ArtProject.DTOs.Art
{
    public class ArtUpdateDto
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
    }
}
