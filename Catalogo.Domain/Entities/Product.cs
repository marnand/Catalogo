using System;
using System.Collections.Generic;
using Catalogo.Domain.Validators;
using Catalogo.Core.Exceptions;

namespace Catalogo.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product(string name, decimal price, int stock, string description, 
                        string imageURL, int categoryId, DateTime createdAt, DateTime? updatedAt = null, int id = 0)
        {
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Description = description;
            this.ImageURL = imageURL;
            this.CategoryId = categoryId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Id = id;
            _errors = new List<string>();

            Validate();
        }
        
        public int Id { get; private set; }
        
        public string Name { get; private set; }
        
        public decimal Price { get; private set; }
        
        public int Stock { get; private set; }
        
        public string Description { get; private set; }
        
        // add checkbox no front: "Não incluir imagem". Caso não incluir inserir uma imagem aleatória unsplash
        public string ImageURL { get; private set; } 
        
        public int CategoryId { get; private set; }
        
        public DateTime CreatedAt { get; private set; }
        
        public DateTime? UpdatedAt { get; private set; }

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