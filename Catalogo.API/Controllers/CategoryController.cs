using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Core.Exceptions;

namespace Catalogo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CategoryController : Controller
    {
        public CategoryController()
        {

        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        var categories = await

        //        return categories;
        //    }
        //    catch (DomainException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500);
        //    }
        //}
    }
}
