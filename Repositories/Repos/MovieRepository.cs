
using Entites;
using Entities.Data;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class MovieRepository : BaseRepository<Movie> ,IMovieRepository
    {
     

        public MovieRepository(MovieDbContext context) :base(context)
        {
            
        }
    }
}
