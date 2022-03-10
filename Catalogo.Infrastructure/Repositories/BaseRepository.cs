using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interfaces;
using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly CatalogoContext _context;

        public BaseRepository(CatalogoContext context)
        {
            _context = context;
        }

        public Task<T> Create(T obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Update(T obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public Task<T> Get(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
