using MovieAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppAppication.Interface.IRepository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();

        Task<Movie> GetByIdAsync(int id);

        Task<bool> CreateAsync(Movie movie);

        Task<bool> UpdateAsync(Movie movie);

        Task<bool> DeleteAsync(int id);
    }
}
