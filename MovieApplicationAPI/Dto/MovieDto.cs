using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MovieAppAPI.Dto
{
    public class MovieDto
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string PhotoPath { get; set; }
    }
}
