using Catalogo.Domain.Entities;
using FluentValidation;

namespace Catalogo.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("A entidade não pode ser vazia.")
                .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome não pode ser vazio.")
                .NotNull().WithMessage("O nome não pode ser nulo.") 
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(20).WithMessage("O nome deve ter no máximo 20 caracteres.");
            
            // RuleFor(x => x.Email).NotEmpty().WithMessage("O email não pode ser vazio.")
            //     .NotNull().WithMessage("O email não pode ser nulo.") 
            //     .MinimumLength(10).WithMessage("O email deve ter no mínimo 10 caracteres.")
            //     .MaximumLength(180).WithMessage("O email deve ter no máximo 180 caracteres.")
            //     .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            //     .WithMessage("O email informado não é válido.");
        }
    }
}