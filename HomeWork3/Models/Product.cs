using System;

namespace FoodOrdering
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductType Type { get; set; }

        public Product(string name, string description, decimal price, ProductType type, int quantity) 
        {
            Name = name;
            Description = description;
            Price = price;
            Type = type;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Description: {1}, Price: {2}, Type: {3}, Quantity: {4}"
                , Name, Description, Price, Type.ToString(), Quantity);
        }
    }
}
