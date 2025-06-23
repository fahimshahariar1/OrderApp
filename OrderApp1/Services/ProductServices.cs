using OrderApp1.Models;
using Serilog;

namespace OrderApp1.Services
{
    internal class ProductServices
    {
        private readonly List<Product> products = new();
        private int _nextId = 1;

        public async Task AddProductAsync(string name, decimal price)
        {
            try
            {
                await Task.Delay(300); // Simulate async operation

                var product = new Product
                {
                    Id = _nextId++,
                    Name = name,
                    Price = price
                };
                products.Add(product);
                Log.Information($"Product Added: {name}, Price: {price}");
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"Failed to add product: {name}");
                throw;
            }


        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product? GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
