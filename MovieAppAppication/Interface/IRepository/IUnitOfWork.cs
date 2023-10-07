using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppAppication.Interface.IRepository
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepo { get; set; }
        IUserRepository UserRepo { get; set; }
        ICommentRepository CommentRepo { get; set; }

        void Save();

        Task<bool> SaveChangesAsync();

    }
}
