using Catalogo.Application.DTO;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Catalogo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDTO)
        {
            DateTime created = DateTime.Now;
            var category = new Category(categoryDTO.Name, categoryDTO.ImageURL, created);
            category.Validate();

            var categoryCreated = await _categoryRepository.Create(category);

            var categoryDTOCreated = new CategoryDTO(categoryCreated.Id, categoryCreated.Name, categoryCreated.ImageURL);

            return categoryDTOCreated;
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
