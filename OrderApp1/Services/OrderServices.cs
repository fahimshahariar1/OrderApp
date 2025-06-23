using OrderApp1.Models;
using Serilog;

namespace OrderApp1.Services
{
    internal class OrderServices
    {
        private readonly List<Order> orders = new();
        private int _nextOrderId = 1;

        public async Task CreateOrderAsync(Customer customer, List<(Product product, int quantity)> items)
        {
            try
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
                Log.Information($"Order Created: {order.Id} for {customer.Name} with {items.Count} items. Total Amount: ${order.TotalAmount}");

            }
            catch (Exception)
            {
                Log.Error($"Failed to create order for customer {customer?.Name ?? "Unknown"}");
                throw;
            }




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
