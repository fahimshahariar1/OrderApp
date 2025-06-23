using OrderApp1.Models;

namespace OrderApp1.Services
{
    internal class CustomerServices
    {
        private readonly List<Customer> customers = new();
        private int _nextId = 1;

        public void AddCustomer(string name, string email)
        {
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
