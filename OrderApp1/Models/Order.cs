namespace OrderApp1.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; } = new();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal TotalAmount => Items.Sum(item => item.TotalAmount);

        public override string ToString()
        {

            return $"Order {Id} for {Customer.Name} {CreatedAt} - Total: ${TotalAmount}";
        }
    }
}
