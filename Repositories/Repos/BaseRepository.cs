using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.Repos
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MovieDbContext _context;

        public BaseRepository(MovieDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var movie= _context.Movies.Find(id);
            _context.Movies.Remove(movie);
        }

        public List<T> GetAllAsync()
        {
            return  _context.Set<T>().ToList();
        }

        public T GetByIdAsync(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
