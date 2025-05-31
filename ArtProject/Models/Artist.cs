using System.ComponentModel.DataAnnotations;

namespace ArtProject.Models
{
    public class Artist : Base
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(20)]
        public string Surname { get; set; }
        public ICollection<Art> Arts = new List<Art>();
    }
}
