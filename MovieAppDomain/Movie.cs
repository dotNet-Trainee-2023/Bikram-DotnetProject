using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppDomain
{
    public class Movie
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Director {  get; set; }
        public string? Genre {  get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PhotoPath { get; set; }
       
        
    }
}
