using MovieAppAPI.Data;
using MovieAppAppication.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppInfrastructure.Implementation.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MovieDb _context;
        public IMovieRepository MovieRepo { get; set; }
        public IUserRepository UserRepo { get; set; }
        public ICommentRepository CommentRepo { get; set; }

        public UnitOfWork(MovieDb context)
        {
            _context = context;
            MovieRepo = new MovieRepository(context);
            UserRepo=new UserRepository(context);
            CommentRepo = new CommentRepository(context);
        }


        public void Save()
        {
            _context.SaveChanges();
          
        }

        public async Task<bool> SaveChangesAsync()
        {
              await _context.SaveChangesAsync();
            return true;
        }

      
    }
}
