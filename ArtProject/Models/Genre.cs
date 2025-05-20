using System.ComponentModel.DataAnnotations;

namespace ArtProject.Models
{
    public class Genre : Base
    {
        [Required(ErrorMessage = "Genre is required")]
        [MaxLength(20)]
        public string Janri { get; set; }
        public ICollection<Art> Books = new List<Art>();
    }
}
