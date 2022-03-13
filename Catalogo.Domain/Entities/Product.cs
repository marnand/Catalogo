using System;
using System.Collections.Generic;
using Catalogo.Domain.Validators;
using Catalogo.Core.Exceptions;

namespace Catalogo.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        { }

        public Product(string name, decimal price, int stock, string description, 
                        string imageURL, int categoryId, DateTime createdAt, DateTime? updatedAt = null, int id = 0)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            ImageURL = imageURL;
            CategoryId = categoryId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Id = id;
            _errors = new List<string>();

            Validate();
        }      
        
        public string Name { get; private set; }
        
        public decimal Price { get; private set; }
        
        public int Stock { get; private set; }
        
        public string Description { get; private set; }
        
        // add checkbox no front: "Não incluir imagem". Caso não incluir inserir uma imagem aleatória unsplash
        public string ImageURL { get; private set; } 
        
        public int CategoryId { get; private set; }

        #region Methods
        
        public override bool Validate()
        {
            var validator = new ProductValidator();
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