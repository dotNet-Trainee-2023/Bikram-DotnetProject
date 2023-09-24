using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepo { get; }

        void Save();

        Task SaveAsync();
    }
}
