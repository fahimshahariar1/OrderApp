namespace OrderApp1.Models
{
    internal class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal TotalAmount => Product.Price * Quantity;

        public override string ToString()
        {
            return $"{Product.Name} (x{Quantity}) - Total: ${TotalAmount}";
        }
    }
}
