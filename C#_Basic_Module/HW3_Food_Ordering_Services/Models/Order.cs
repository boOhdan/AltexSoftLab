using System;
using System.Collections.Generic;

namespace FoodOrdering
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

        public Order(string address, string phoneNumber, IEnumerable<OrderItem> orderItems) 
        {
            Address = address;
            PhoneNumber = phoneNumber;
            OrderItems = orderItems;
            OrderDate = DateTime.Now;
            Status = OrderStatus.InProcess;
        }

        public decimal GetFullPrice()
        {
            var price = 0m;

            foreach (var orderItem in OrderItems)
            {
                price += orderItem.Product.Price;
            }

            return price;
        }

        public override string ToString()
        {
            return String.Format("OrderDate: {0}; Address: {1}; PhoneNumber: {2}, Status: {3}",
                OrderDate, Address, PhoneNumber, Status);
        }
    }
}
