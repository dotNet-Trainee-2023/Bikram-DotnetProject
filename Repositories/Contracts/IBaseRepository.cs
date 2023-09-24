using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBaseRepository<T>
    {
        List<T> GetAllAsync();

        T GetByIdAsync(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
