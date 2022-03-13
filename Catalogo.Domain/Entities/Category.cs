using System;
using System.Collections.Generic;
using Catalogo.Core.Exceptions;
using Catalogo.Domain.Validators;

namespace Catalogo.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        { }

        public Category(string name, string imageURL, DateTime createdAt, 
                        DateTime? updatedAt = null, int id = 0)
        {
            Name = name;
            ImageURL = imageURL;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Id = id;
            _errors = new List<string>();

            Validate();
        }
        
        public string Name { get; private set; }
        
        // add checkbox no front: "Não incluir imagem". Caso não incluir inserir uma imagem aleatória unsplash
        public string ImageURL { get; private set; }

        #region Methods
        
        public override bool Validate()
        {
            var validator = new CategoryValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new DomainException("Alguns campos estão inválidos.", _errors);
            }

            return true;
        }
        
        #endregion
    }
}