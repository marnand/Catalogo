namespace Catalogo.Application.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO()
        { }

        public CategoryDTO(int id, string name, string imageURL)
        {
            Id = id;
            Name = name;
            ImageURL = imageURL;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string ImageURL { get; private set; }
    }
}
