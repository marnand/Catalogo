using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Core.Exceptions;
using Catalogo.API.ViewModels;
using Catalogo.Application.Interfaces;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _categoryService.Get();

                var result = new ResultViewModel();
                result.Data = null;
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
    }
}
