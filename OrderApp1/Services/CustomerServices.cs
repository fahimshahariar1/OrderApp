using OrderApp1.Models;

namespace OrderApp1.Services
{
    internal class CustomerServices
    {
        private readonly List<Customer> customers = new();
        private int _nextId = 1;

        public async Task AddCustomerAsync(string name, string email)
        {

            await Task.Delay(200); // Simulate async operation
            var customer = new Customer
            {
                Id = _nextId++,
                Name = name,
                Email = email
            };
            customers.Add(customer);
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
