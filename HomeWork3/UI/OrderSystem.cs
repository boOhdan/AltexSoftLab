using FoodOrdering.Contracts;
using FoodOrdering.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FoodOrdering
{
    public class OrderSystem
    {
        public string Name { get; set; }
        public IProductService ProductService { get; set; }
        public IMessageService MessageService { get; set; }
        public IValidationService ValidationService { get; set; }

        public OrderSystem(string name, IMessageService messageService, IProductService productService, IValidationService validationService) 
        {
            Name = name;
            MessageService = messageService;
            ProductService = productService;
            ValidationService = validationService;
        }

        public void Start() 
        {
            while(true) 
            {
                MessageService.SendMessage("Виберiть операцiю:");
                MessageService.SendMessage("1. Додати продукт;");
                MessageService.SendMessage("2. Зробити замовлення;");
                MessageService.SendMessage("3. Показати продукти в наявностi;");
                MessageService.SendMessage("4. Завершити роботу.");

                var result = false;

                switch(MessageService.ReceiveMessage().Trim())
                {
                    case "1":
                        result = AddProduct();
                        break;
                    case "2":
                        result = OrderProduct();
                        break;
                    case "3":
                        result = ShowAllProducts();
                        break;
                    case "4":
                        return;
                    default:
                        MessageService.SendMessage("Введенi некоректнi данi!");
                        break;
                };

                FinishOperation(result);
            }
        }

        public bool AddProduct() 
        {
            Product product = default;

            while (true) 
            {
                MessageService.SendMessage("Вкажiть назву продукту:");
                var name = MessageService.ReceiveMessage();

                MessageService.SendMessage("Вкажiть опис продукту:");
                var description = MessageService.ReceiveMessage();

                MessageService.SendMessage("Вкажiть цiну продукту:");
                var price = decimal.Parse(MessageService.ReceiveMessage());

                if (!ValidationService.IsPositiveNumber(price))
                {
                    MessageService.SendMessage("Ціна не може бути вiдємною!");
                    return false;
                }

                MessageService.SendMessage("Вкажiть тип продукту:");

                foreach (var typeItem in ProductService.GetProductTypes())
                {
                    MessageService.SendMessage($"{typeItem.Key} - {typeItem.Value}");
                }

                var typeNumber = int.Parse(MessageService.ReceiveMessage());

                if (!ValidationService.IsSuchTypeExist(typeNumber)) 
                {
                    MessageService.SendMessage("Вибраного вами типу не існує!");
                    return false;
                }

                MessageService.SendMessage("Вкажiть кiлькiсть продукту:");
                var quantity = int.Parse(MessageService.ReceiveMessage());

                if (!ValidationService.IsPositiveNumber(quantity))
                {
                    MessageService.SendMessage("Кiлькiсть не може бути вiдємною!");
                    return false;
                }

                product = new Product(name, description, price, (ProductType)typeNumber, quantity);

                ProductService.AddProduct(product); 

                if (!AskQuestion("Бажаєте ще додати продукт?"))
                    break;
            }
            
            return true;
        }

        public bool OrderProduct() 
        {
            Order order = default;
            IEnumerable<OrderItem> orderItems = new List<OrderItem>();

            while (true)
            {
                MessageService.SendMessage("Виберiть номер типу продукту, який бажаєте замовити:");

                foreach (var typeItem in ProductService.GetProductTypes())
                {
                    MessageService.SendMessage($"{typeItem.Key} - {typeItem.Value}");
                }

                var typeNumber = int.Parse(MessageService.ReceiveMessage());

                if (!ValidationService.IsSuchTypeExist(typeNumber))
                {
                    MessageService.SendMessage("Вибраного вами типу не iснує!");
                    return false;
                }

                if (!ValidationService.IsTheraAnyProductWithSuchType((ProductType)typeNumber))
                {
                    MessageService.SendMessage("Продуктiв з таким типом немає в наявностi!");
                    return false;
                }

                MessageService.SendMessage("Виберiть продукт, який бажаєте замовити:");

                foreach (var productItem in ProductService.GetProductsByType((ProductType)typeNumber)) 
                {
                    MessageService.SendMessage($"{productItem.Key} - {productItem.Value}");
                }

                var productNumber = int.Parse(MessageService.ReceiveMessage());

                if (!ValidationService.IsSuchProductExist(productNumber))
                {
                    MessageService.SendMessage("Продукт не iснує!"); 
                    return false;
                }

                if (!ValidationService.IsProductHasSuchType(productNumber, (ProductType)typeNumber))
                {
                    MessageService.SendMessage("Продукт не належить до вибраного вами типу!"); 
                    return false;
                }

                MessageService.SendMessage("Введiть кiлькiсть:");

                var quantity = int.Parse(MessageService.ReceiveMessage());

                if (!ValidationService.HasSystemEnoughProducts(productNumber, quantity))
                {
                    MessageService.SendMessage("Недостатня кiлькiсть товару на складi!"); 
                    return false;
                }

                ProductService.ReduceProductQuantity(productNumber, quantity);

                orderItems = orderItems.Append(new OrderItem(ProductService.GetProductById(productNumber), quantity));

                if (!AskQuestion("Бажаєте ще замовити продукт?"))
                    break;
            }

            MessageService.SendMessage("Введiть aдрес:");
            var address = MessageService.ReceiveMessage();

            MessageService.SendMessage("Введiть номер:");
            var phoneNumber = MessageService.ReceiveMessage();

            order = new Order(address, phoneNumber, orderItems);

            MessageService.SendMessage(order.ToString());

            return true;
        }

        public bool AskQuestion(string message) 
        {
            MessageService.SendMessage(message);

            MessageService.SendMessage("1. Так");
            MessageService.SendMessage("2. Нi");

            return int.Parse(MessageService.ReceiveMessage()) switch
            {
                1 => true, 
                2 => false,
                _ => throw new ArgumentException()
            };
        }

        public bool ShowAllProducts() 
        {
            if (!ValidationService.IsProductsNotEmpty()) 
            {
                MessageService.SendMessage("Склад продуктiв пустий!");
                return false;
            }

            foreach (var product in  ProductService.GetAllProducts()) 
            {
                MessageService.SendMessage(product.ToString());
            }

            return true;
        }

        public void FinishOperation(bool result)
        {
            if (result)
                MessageService.SendMessage("<<Операцiя виконана успiшно>>");
            else
                MessageService.SendMessage("<<Операцiя провалилась>>");

            MessageService.SendMessage("\n_____________________________________________\n");
        }
    }
}
