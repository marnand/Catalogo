using System;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    public class Category
    {
        public Category(string name, Product product, string imageURL, 
                        DateTime createdAt, DateTime? updatedAt = null, int id = 0)
        {
            this.Name = name;
            this.ImageURL = imageURL;
            Products.Add(product);
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Id = id;
        }

        public int Id { get; private set; }
        
        public string Name { get; private set; }
        
        // add checkbox no front: "Não incluir imagem". Caso não incluir inserir uma imagem aleatória unsplash
        public string ImageURL { get; private set; }
        
        public List<Product> Products { get; private set; }

        public DateTime CreatedAt { get; private set; }
        
        public DateTime? UpdatedAt { get; private set; }
    }
}