using OrderApp1.Models;
using OrderApp1.Services;


var productService = new ProductServices();

productService.AddProduct(name: "Laptop", 1200.50m);
productService.AddProduct(name: "Keyboard", 100m);

Console.WriteLine("Available Products:");
foreach (var p in productService.GetAllProducts())
{
    Console.WriteLine(p);
}

var customerService = new CustomerServices();

customerService.AddCustomer("Alice", "alice@example.com");
customerService.AddCustomer("Bob", "bob@example.com");

Console.WriteLine("\nCustomers:");
foreach (var c in customerService.GetAllCustomers())
{
    Console.WriteLine(c);
}

var orderService = new OrderServices();

var customer = customerService.GetCustomerById(1);
var product1 = productService.GetProductById(1);
var product2 = productService.GetProductById(2);

if (customer != null && product1 != null && product2 != null)
{
    orderService.CreateOrder(customer, new List<(Product, int)>
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
