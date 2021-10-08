using FoodOrdering.Contracts;
using FoodOrdering.Models;
using FoodOrdering.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FoodOrdering
{
    public class OrderSystem
    {
        private readonly string _name;
        private readonly IProductService _productService;
        private readonly IMessageService _messageService;
        private readonly IValidationService _validationService;
        private readonly ILogger _logger;
        private readonly IExchangeRateService _exchangeRateService;

        public OrderSystem(string name, IMessageService messageService, IProductService productService, IValidationService validationService, ILogger logger, IExchangeRateService exchangeRateService) 
        {
            _name = name;
            _messageService = messageService;
            _productService = productService;
            _validationService = validationService;
            _logger = logger;
            _exchangeRateService = exchangeRateService;
        }

        public void Start() 
        {
            while(true) 
            {
                _messageService.SendMessage("Виберiть операцiю:");
                _messageService.SendMessage("1. Додати продукт;");
                _messageService.SendMessage("2. Зробити замовлення;");
                _messageService.SendMessage("3. Показати продукти в наявностi;");
                _messageService.SendMessage("4. Завершити роботу.");

                var result = false;

                switch(_messageService.ReceiveMessage().Trim())
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
                        _messageService.SendMessage("Введенi некоректнi данi!");
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
                _messageService.SendMessage("Вкажiть назву продукту:");
                var name = _messageService.ReceiveMessage();

                _messageService.SendMessage("Вкажiть опис продукту:");
                var description = _messageService.ReceiveMessage();

                _messageService.SendMessage("Вкажiть цiну продукту:");
                var price = decimal.Parse(_messageService.ReceiveMessage());

                if (!_validationService.IsPositiveNumber(price))
                {
                    _messageService.SendMessage("Ціна не може бути вiдємною!");
                    return false;
                }

                _messageService.SendMessage("Вкажiть тип продукту:");

                foreach (var typeItem in _productService.GetProductTypes())
                {
                    _messageService.SendMessage($"{typeItem.Key} - {typeItem.Value}");
                }

                var typeNumber = int.Parse(_messageService.ReceiveMessage());

                if (!_validationService.IsSuchTypeExist(typeNumber)) 
                {
                    _messageService.SendMessage("Вибраного вами типу не існує!");
                    return false;
                }

                _messageService.SendMessage("Вкажiть кiлькiсть продукту:");
                var quantity = int.Parse(_messageService.ReceiveMessage());

                if (!_validationService.IsPositiveNumber(quantity))
                {
                    _messageService.SendMessage("Кiлькiсть не може бути вiдємною!");
                    return false;
                }

                product = new Product(_productService.GetProductsCount(),  name, description, price, (ProductType)typeNumber, quantity);

                _productService.AddProduct(product);
                _logger.Append(product, OperationType.Add);

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
                _messageService.SendMessage("Виберiть номер типу продукту, який бажаєте замовити:");

                foreach (var typeItem in _productService.GetProductTypes())
                {
                    _messageService.SendMessage($"{typeItem.Key} - {typeItem.Value}");
                }

                var typeNumber = int.Parse(_messageService.ReceiveMessage());

                if (!_validationService.IsSuchTypeExist(typeNumber))
                {
                    _messageService.SendMessage("Вибраного вами типу не iснує!");
                    return false;
                }

                if (!_validationService.IsTheraAnyProductWithSuchType((ProductType)typeNumber))
                {
                    _messageService.SendMessage("Продуктiв з таким типом немає в наявностi!");
                    return false;
                }

                _messageService.SendMessage("Виберiть продукт, який бажаєте замовити:");

                foreach (var productItem in _productService.GetProductsByType((ProductType)typeNumber)) 
                {
                    _messageService.SendMessage($"{productItem.Key} - {productItem.Value}");
                }

                var productNumber = int.Parse(_messageService.ReceiveMessage());

                if (!_validationService.IsSuchProductExist(productNumber))
                {
                    _messageService.SendMessage("Продукт не iснує!"); 
                    return false;
                }

                if (!_validationService.IsProductHasSuchType(productNumber, (ProductType)typeNumber))
                {
                    _messageService.SendMessage("Продукт не належить до вибраного вами типу!"); 
                    return false;
                }

                _messageService.SendMessage("Введiть кiлькiсть:");

                var quantity = int.Parse(_messageService.ReceiveMessage());

                if (!_validationService.HasSystemEnoughProducts(productNumber, quantity))
                {
                    _messageService.SendMessage("Недостатня кiлькiсть товару на складi!"); 
                    return false;
                }

                _productService.ReduceProductQuantity(productNumber, quantity);

                orderItems = orderItems.Append(new OrderItem(_productService.GetProductById(productNumber), quantity));

                if (!AskQuestion("Бажаєте ще замовити продукт?"))
                    break;
            }

            _messageService.SendMessage("Введiть aдрес:");
            var address = _messageService.ReceiveMessage();

            if (!_validationService.IsAddressValid(address))
            {
                _messageService.SendMessage("Адрес не пройшов валідацію!");
                return false;
            }

            _messageService.SendMessage("Введiть номер:");
            var phoneNumber = _messageService.ReceiveMessage();

            if (!_validationService.IsNumberValid(phoneNumber))
            {
                _messageService.SendMessage("Номер телефону не пройшов валідацію!");
                return false;
            }

            order = new Order(address, phoneNumber, orderItems);

            if(AskQuestion("Бажаєте змінити валюту?")) 
            {
                foreach (var exchangeRate in _exchangeRateService.GetExchangeRates())
                {
                    _messageService.SendMessage(exchangeRate.Currency);
                }

                _messageService.SendMessage("Виберiть одну з перелічених вище валют:");

                var currency = _messageService.ReceiveMessage();

                _messageService.SendMessage(string.Format("До сплати {0} {1}", _exchangeRateService.ChangeCurrency(order.GetFullPrice(), currency),
                    _exchangeRateService.GetExchangeRate(currency).Currency));
            }

            _logger.Append(order, OperationType.Add);

            return true;
        }

        public bool AskQuestion(string message) 
        {
            _messageService.SendMessage(message);

            _messageService.SendMessage("1. Так");
            _messageService.SendMessage("2. Нi");

            return int.Parse(_messageService.ReceiveMessage()) switch
            {
                1 => true, 
                2 => false,
                _ => throw new ArgumentException()
            };
        }

        public bool ShowAllProducts() 
        {
            if (!_validationService.IsProductsNotEmpty()) 
            {
                _messageService.SendMessage("Склад продуктiв пустий!");
                return false;
            }

            foreach (var product in  _productService.GetAllProducts()) 
            {
                _messageService.SendMessage(product.ToString());
            }

            return true;
        }

        public void FinishOperation(bool result)
        {
            if (result)
                _messageService.SendMessage("<<Операцiя виконана успiшно>>");
            else
                _messageService.SendMessage("<<Операцiя провалилась>>");

            _messageService.SendMessage("\n_____________________________________________\n");
        }
    }
}
