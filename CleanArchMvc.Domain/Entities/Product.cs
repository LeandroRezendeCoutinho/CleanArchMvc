
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name. Name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name. Name must have at least 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid Description. Description is required");
            DomainExceptionValidation.When(description.Length < 10,
                "Invalid Description. Description must have at least 10 characters");
            DomainExceptionValidation.When(price < 0, "Invalid Price");
            DomainExceptionValidation.When(stock < 0, "Invalid Stock");
            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid Image. Image is required");
            DomainExceptionValidation.When(image.Length > 25,
                "Invalid image name, maximum of 25 characters");
            
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

    }
}