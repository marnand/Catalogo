using Catalogo.Application.DTO;
using Catalogo.Application.Interfaces;
using Catalogo.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDTO>> Get()
        {
            var categories = await _categoryRepository.Get();
            List<CategoryDTO> categoriesDTO = null; 

            foreach (var category in categories)
            {
                var categoryDTO = new CategoryDTO(category.Id, category.Name, category.ImageURL);
                categoriesDTO.Add(categoryDTO);
            }

            return categoriesDTO;
        }
    }
}
