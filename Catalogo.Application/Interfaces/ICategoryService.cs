using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogo.Application.DTO;

namespace Catalogo.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Create(CategoryDTO categoryDTO);

        Task<List<CategoryDTO>> Get();
    }
}
