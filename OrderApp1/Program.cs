using OrderApp1.Models;
using OrderApp1.Services;

static async Task Main(string[] args)
{
    var productService = new ProductServices();
    var customerService = new CustomerServices();
    var orderService = new OrderServices();

    await productService.AddProductAsync("Laptop", 1200.50m);
    await productService.AddProductAsync("Keyboard", 100m);

    await customerService.AddCustomerAsync("Alice", "alice@example.com");
    await customerService.AddCustomerAsync("Bob", "bob@example.com");

    var customer = customerService.GetCustomerById(1);
    var product1 = productService.GetProductById(1);
    var product2 = productService.GetProductById(2);

    if (customer != null && product1 != null && product2 != null)
    {
        await orderService.CreateOrderAsync(customer, new List<(Product, int)>
    {
        (product1, 1),
        (product2, 2)
    });

        Console.WriteLine("\nOrders:");
        foreach (var o in orderService.GetAllOrders())
        {
            Console.WriteLine(o);
            foreach (var item in o.Items)
            {
                Console.WriteLine("  " + item);
            }
        }

        Console.WriteLine($"\nTotal Sales: ${orderService.GetTotalSales()}");
    }


}


