using System;
using System.Collections.Generic;
using System.Linq;


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

        public override string ToString()
        {
            string str = String.Format("OrderDate: {0}; \nAddress: {1}; \nPhoneNumber: {2}, \nStatus: {3}",
                OrderDate, Address, PhoneNumber, Status);

            str += "\nOrderItems:";

            foreach(var item in OrderItems) 
            {
                str += "\n" + item;
            }

            return str;
        }
    }
}
