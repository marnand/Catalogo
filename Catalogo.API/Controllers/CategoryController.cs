using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Core.Exceptions;
using Catalogo.API.ViewModels;
using Catalogo.Application.Interfaces;
using Catalogo.Application.DTO;

namespace Catalogo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryViewModel createCategory)
        {
            try
            {
                var categoryDTO = new CategoryDTO(createCategory.Name, createCategory.ImageURL);

                var categoryCreatedDTO = await _categoryService.Create(categoryDTO);

                var result = new ResultViewModel();
                result.Data = categoryCreatedDTO;
                result.Message = "Catagoria criada.";
                result.Success = true;

                return Ok(result);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryViewModel updateCategory)
        {
            try
            {
                var categoryDTO = new CategoryDTO(updateCategory.Id, updateCategory.Name, updateCategory.ImageURL);

                var categoryUpdatedDTO = await _categoryService.Update(categoryDTO);

                var result = new ResultViewModel();
                result.Data = categoryUpdatedDTO;
                result.Message = "Catagoria alterada.";
                result.Success = true;

                return Ok(result);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpDelete("{id}", Name = "remove")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.Remove(id);

                var result = new ResultViewModel();
                result.Data = null;
                result.Message = "Catagoria alterada.";
                result.Success = true;

                return Ok(result);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _categoryService.Get();

                var result = new ResultViewModel();
                result.Data = categories;
                result.Message = "Catagorias encontradas.";
                result.Success = true;

                return Ok(result);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet("{id}", Name = "category")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoryService.Get(id);

                var result = new ResultViewModel();
                result.Data = category;
                result.Message = "Catagoria encontrada.";
                result.Success = true;

                return Ok(result);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
