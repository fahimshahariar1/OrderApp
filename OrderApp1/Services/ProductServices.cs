using OrderApp1.Models;

namespace OrderApp1.Services
{
    internal class ProductServices
    {
        private readonly List<Product> products = new();
        private int _nextId = 1;

        public async Task AddProductAsync(string name, decimal price)
        {
            await Task.Delay(300); // Simulate async operation

            var product = new Product
            {
                Id = _nextId++,
                Name = name,
                Price = price
            };
            products.Add(product);

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
