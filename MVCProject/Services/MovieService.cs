using Entites;
using Microsoft.CodeAnalysis;
using Repositories.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCProject.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {            
            _unitOfWork = unitOfWork;
        }

        public void AddMovie(Movie movie)
        {
            _unitOfWork.MovieRepo.Create(movie);
        }

        public void DeleteMovie(int id)
        {
          _unitOfWork.MovieRepo.Delete(id);
            
        }

        public List<Movie> GetAllMovies()
        {
            return  _unitOfWork.MovieRepo.GetAllAsync();
        }

        public Movie? GetMovie(int id)
        {
            return _unitOfWork.MovieRepo.GetByIdAsync(id);
        }

       

        public void UpdateMovie(Movie movie)
        {
            var viewmovie = _unitOfWork.MovieRepo.GetByIdAsync(movie.Id);
            if (viewmovie != null)
            {
                viewmovie.Name = movie.Name;
                viewmovie.Genre = movie.Genre;
                viewmovie.Director = movie.Director;
                viewmovie.ReleaseDate = movie.ReleaseDate;

                _unitOfWork.MovieRepo.Update(viewmovie);
            }
        }
    }
}
