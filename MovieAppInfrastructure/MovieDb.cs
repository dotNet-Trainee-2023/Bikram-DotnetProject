using Microsoft.EntityFrameworkCore;
using MovieAppDomain;

namespace MovieAppAPI.Data
{
    public class MovieDb:DbContext
    {
        public MovieDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.CommentId);
            modelBuilder.Entity<Comment>().HasIndex(c => c.MovieId).IsUnique(false);

            string plainPassword = "Leomessi10@"; 
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

           
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                UserName = "BikramShrestha",
                PasswordHash = hashedPassword,
                Email = "stha.bikram999@gmail.com",
                FirstName = "Bikram",
                LastName = "Stha",
                Role = "Admin"
            });
        modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("User");
        }
       
    }
}


