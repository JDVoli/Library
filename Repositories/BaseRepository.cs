using System;
using System.Threading.Tasks;
using Library.Entities;
using Library.Repositories.Interfaces;

namespace Library.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        protected readonly LibraryContext _context;

        protected BaseRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
