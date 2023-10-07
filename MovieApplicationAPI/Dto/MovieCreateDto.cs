using System.ComponentModel.DataAnnotations;

namespace MovieAppAPI.Dto
{
    public class MovieCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public IFormFile MovieImage { get; set; }
    }
}
