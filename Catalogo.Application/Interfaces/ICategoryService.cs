using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogo.Application.DTO;

namespace Catalogo.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Create(CategoryDTO categoryDTO);

        Task<CategoryDTO> Update(CategoryDTO categoryDTO);

        Task Remove(int Id);

        Task<List<CategoryDTO>> Get();

        Task<CategoryDTO> Get(int Id);
    }
}
