using Entites;

namespace MVCProject.Services
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();

        Movie? GetMovie(int id);

        void AddMovie(Movie movie);

        void UpdateMovie(Movie movie);

        void DeleteMovie(int id);
    }
}
