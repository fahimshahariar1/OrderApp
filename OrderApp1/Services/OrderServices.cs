using OrderApp1.Models;

namespace OrderApp1.Services
{
    internal class OrderServices
    {
        private readonly List<Order> orders = new();
        private int _nextOrderId = 1;

        public async Task CreateOrderAsync(Customer customer, List<(Product product, int quantity)> items)
        {
            if (customer == null || items == null || !items.Any())
            {
                throw new ArgumentException("Inavlid Order Data");
            }

            await Task.Delay(500); // Simulate async operation

            var order = new Order
            {
                Id = _nextOrderId++,
                Customer = customer,
                Items = items.Select(i => new OrderItem
                {
                    Product = i.product,
                    Quantity = i.quantity,

                }).ToList()
            };

            orders.Add(order);



        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public List<Order> GetOrderByCustomer(int customerid)
        {
            return orders.Where(o => o.Customer.Id == customerid).ToList();
        }

        public decimal GetTotalSales()
        {
            return orders.Sum(o => o.TotalAmount);
        }

    }
}
