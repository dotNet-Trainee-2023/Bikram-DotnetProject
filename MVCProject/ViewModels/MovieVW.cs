using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class MovieVW
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
