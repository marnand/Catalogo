using Catalogo.Domain.Entities;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interfaces;

namespace Catalogo.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly CatalogoContext _context;

        public CategoryRepository(CatalogoContext context) : base(context)
        {
            _context = context;
        }
    }
}
