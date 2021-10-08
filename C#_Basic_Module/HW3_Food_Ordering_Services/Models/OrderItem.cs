using System;

namespace FoodOrdering
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Product product, int quantity) 
        {
            Product = product;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return String.Format("Product: {0}, Quantity: {1}", Product, Quantity);
        }
    }
}
