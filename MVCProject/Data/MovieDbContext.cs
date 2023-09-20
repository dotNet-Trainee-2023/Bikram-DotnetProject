using Microsoft.EntityFrameworkCore;
using MVCProject.Model;

namespace MVCProject.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
