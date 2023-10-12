using MovieAppAPI.Dto;
using MovieAppDomain;

namespace MovieAppAPI.Services
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMoviesAsync();

        Task<MovieDto> GetMovieAsync(int id);

        Task<bool> AddMovieAsync(MovieCreateDto movieDto);

        Task<bool> UpdateMovieAsync(MovieUpdateDto movieDto);

        Task<bool> DeleteMovieAsync(int id);
    }
}
