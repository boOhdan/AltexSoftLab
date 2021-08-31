namespace FoodOrdering
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductType Type { get; set; }

        public Product(int id, string name, string description, decimal price, ProductType type, int quantity) 
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Type = type;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Description: {2}, Price: {3}, Type: {4}, Quantity: {5}",
                Id, Name, Description, Price, Type.ToString(), Quantity);
        }
    }
}
