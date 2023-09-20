using MVCProject.Data;
using MVCProject.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCProject.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext movieDbContext)
        {
            _context = movieDbContext;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            Movie? movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetMovie(int id)
        {
            return _context.Movies.Find(id);
        }

        public void UpdateMovie(Movie movie)
        {
            var viewmovie = _context.Movies.Find(movie.Id);
            if (viewmovie != null)
            {
                viewmovie.Name = movie.Name;
                viewmovie.Genre = movie.Genre;
                viewmovie.Director = movie.Director;
                viewmovie.ReleaseDate = movie.ReleaseDate;

                _context.Movies.Update(viewmovie);
                _context.SaveChanges();
            }
        }
    }
}
