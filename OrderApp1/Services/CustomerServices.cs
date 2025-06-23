using OrderApp1.Models;
using Serilog;

namespace OrderApp1.Services
{
    internal class CustomerServices
    {
        private readonly List<Customer> customers = new();
        private int _nextId = 1;

        public async Task AddCustomerAsync(string name, string email)
        {

            try
            {
                await Task.Delay(200); // Simulate async operation
                var customer = new Customer
                {
                    Id = _nextId++,
                    Name = name,
                    Email = email
                };
                customers.Add(customer);
                Log.Information($"Customer Added: {name}, Email: {email}");
            }
            catch (Exception)
            {
                Log.Error($"Failed to add customer: {name}");
                throw;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer? GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

    }
}
