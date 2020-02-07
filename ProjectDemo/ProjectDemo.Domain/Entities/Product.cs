using ProjectDemo.Domain.Exceptions;
using System;

namespace ProjectDemo.Domain.Products
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetPrice(price);
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ProjectDemoValidationException("Product name cannot be null or empty.");
            }
            if(!(name.Length <= 100))
            {
                throw new ProjectDemoValidationException("Product name cannot exceed 100 characters.");
            }

            Name = name;
        }

        public void SetPrice(decimal price)
        {
            if(price < 0)
            {
                throw new ProjectDemoValidationException("Price cannot be lower than 0.");
            }

            Price = price;
        }
    }
}
