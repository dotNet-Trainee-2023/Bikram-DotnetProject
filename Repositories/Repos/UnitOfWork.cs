
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;

        public UnitOfWork(MovieDbContext context)
        {
            _context = context;
            MovieRepo = new MovieRepository(context);
        }

        public IMovieRepository MovieRepo {  get; set; }


        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
