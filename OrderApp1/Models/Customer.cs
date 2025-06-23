namespace OrderApp1.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} ({Email})";
        }


    }
}
