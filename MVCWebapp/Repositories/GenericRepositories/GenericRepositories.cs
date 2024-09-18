using Microsoft.EntityFrameworkCore;
using MVCWebapp.Data;
using MVCWebapp.Models;

namespace MVCWebapp.Repositories.GenericRepositories
{
    public class GenericRepositories : IGenericRepositories
    {
        private readonly MVCWebappContext _context;
        public GenericRepositories(MVCWebappContext context) 
        { 
            _context = context;
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> SelectbyId<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task UpdatebyId<T>(int id, T instance) where T : class
        {
            _context.Set<T>().Update(instance);
            await _context.SaveChangesAsync();
        }

        public async Task Create<T>(T instance) where T : class
        {
            _context.Set<T>().Add(instance);
            await _context.SaveChangesAsync();
        }
    }
}
