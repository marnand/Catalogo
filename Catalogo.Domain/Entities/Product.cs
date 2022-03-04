using System;

namespace Catalogo.Domain.Entities
{
    public class Product
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
    }
}