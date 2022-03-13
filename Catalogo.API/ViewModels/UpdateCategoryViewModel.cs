using System.ComponentModel.DataAnnotations;

namespace Catalogo.API.ViewModels
{
    public class UpdateCategoryViewModel
    {
        [Required(ErrorMessage = "O Id deve ser informado.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado.")]
        [MinLength(3, ErrorMessage = "O nome deve ter mais de 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "O nome deve não deve ter mais que 30 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A imagem deve ser inserida.")]
        public string ImageURL { get; set; }
    }
}
