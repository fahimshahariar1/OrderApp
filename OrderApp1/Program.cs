
using OrderApp1.Models;
using OrderApp1.Services;
using Serilog;

class Program
{
    static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

        try
        {
            var productService = new ProductServices();
            var customerService = new CustomerServices();
            var orderService = new OrderServices();

            bool running = true;
            while (running)
            {
                ShowMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Product name: ");
                        var pname = Console.ReadLine();
                        Console.Write("Price: ");
                        var price = decimal.Parse(Console.ReadLine() ?? "0");
                        await productService.AddProductAsync(pname, price);
                        Console.WriteLine("✅ Product added.");
                        break;

                    case "2":
                        Console.Write("Customer name: ");
                        var cname = Console.ReadLine();
                        Console.Write("Email: ");
                        var email = Console.ReadLine();
                        await customerService.AddCustomerAsync(cname, email);
                        Console.WriteLine("✅ Customer added.");
                        break;

                    case "3":
                        Console.WriteLine("Customers:");
                        foreach (var c in customerService.GetAllCustomers())
                            Console.WriteLine(c);

                        Console.Write("Customer ID: ");
                        var custId = int.Parse(Console.ReadLine() ?? "0");
                        var customer = customerService.GetCustomerById(custId);
                        if (customer == null)
                        {
                            Console.WriteLine("❌ Customer not found.");
                            break;
                        }

                        var items = new List<(Product, int)>();
                        bool addingProducts = true;

                        while (addingProducts)
                        {
                            Console.WriteLine("Products:");
                            foreach (var p in productService.GetAllProducts())
                                Console.WriteLine(p);

                            Console.Write("Product ID (or '0' to stop): ");
                            var pid = int.Parse(Console.ReadLine() ?? "0");
                            if (pid == 0) break;

                            var product = productService.GetProductById(pid);
                            if (product == null)
                            {
                                Console.WriteLine("❌ Product not found.");
                                continue;
                            }

                            Console.Write("Quantity: ");
                            var qty = int.Parse(Console.ReadLine() ?? "1");
                            items.Add((product, qty));
                        }

                        if (items.Count > 0)
                        {
                            await orderService.CreateOrderAsync(customer, items);
                            Console.WriteLine("✅ Order placed.");
                        }
                        break;

                    case "4":
                        foreach (var o in orderService.GetAllOrders())
                        {
                            Console.WriteLine(o);
                            foreach (var item in o.Items)
                                Console.WriteLine("  " + item);
                        }
                        break;

                    case "5":
                        Console.WriteLine($"💰 Total Sales: ${orderService.GetTotalSales()}");
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("❓ Invalid option.");
                        break;
                }

            }



            static void ShowMenu()
            {
                Console.WriteLine("\n=== Order Management System ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Orders");
                Console.WriteLine("5. View Total Sales");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option (1-6): ");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred in the application.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}


