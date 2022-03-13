using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interfaces;
using Catalogo.Domain.Entities;
using System.Linq;

namespace Catalogo.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly CatalogoContext _context;

        public BaseRepository(CatalogoContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task Remove(int id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            var obj = await _context.Set<T>().AsNoTracking().Where(x => x.Id == id).ToListAsync();

            return obj.FirstOrDefault();
        }
    }
}
