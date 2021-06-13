namespace FoodOrdering.Services
{
    public class OrderExtension
    {
        public Order Order { get; set; }

        public OrderExtension(Order order) 
        {
            Order = order;
        }

        public decimal GetFullPrice() 
        {
            var price = 0m;

            foreach(var orderItem in Order.OrderItems) 
            {
                price += orderItem.Product.Price;
            }

            return price;
        }
    }
}
