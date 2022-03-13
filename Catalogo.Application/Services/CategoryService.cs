using Catalogo.Application.DTO;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Catalogo.Core.Exceptions;

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

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var categoryExists = await _categoryRepository.Get(categoryDTO.Id);

            if (categoryExists == null)
            {
                throw new DomainException("Esta categoria não existe");
            }

            DateTime updated = DateTime.Now;
            var category = new Category(categoryDTO.Name, categoryDTO.ImageURL, (DateTime)categoryExists.CreatedAt, updated, categoryDTO.Id);
            category.Validate();

            var categoryUpdated = await _categoryRepository.Update(category);

            var categoryDTOUpdated = new CategoryDTO(categoryUpdated.Id, categoryUpdated.Name, categoryUpdated.ImageURL);

            return categoryDTOUpdated;
        }

        public async Task Remove(int id)
        {
            var categoryExists = await _categoryRepository.Get(id);

            if (categoryExists == null)
            {
                throw new DomainException("Esta categoria não existe");
            }

            await _categoryRepository.Remove(categoryExists.Id);
        }

        public async Task<List<CategoryDTO>> Get()
        {
            var categories = await _categoryRepository.Get();
            var categoriesDTO = new List<CategoryDTO>(); 

            foreach (var category in categories)
            {
                var categoryDTO = new CategoryDTO(category.Id, category.Name, category.ImageURL);
                categoriesDTO.Add(categoryDTO);
            }

            return categoriesDTO;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            Category categoryExists = await _categoryRepository.Get(id);

            if (categoryExists == null)
            {
                throw new DomainException("Esta categoria não existe");
            }

            var categoryDTO = new CategoryDTO(categoryExists.Id, categoryExists.Name, categoryExists.ImageURL);

            return categoryDTO;
        }
    }
}
