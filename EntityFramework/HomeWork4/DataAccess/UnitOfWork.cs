using FoodOrderingSystem.Contracts;
using FoodOrderingSystem.Date;
using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private FoodOrderingContext _context;
        private Repository<Customer> _customersRepo;
        private Repository<Order> _ordersRepo;
        private Repository<OrderItem> _orderItemsRepo;
        private Repository<Product> _productsRepo;
        private Repository<ProductCategory> _productCategoriesRepo;
        private Repository<Supplier> _suppliersRepo;

        public UnitOfWork(FoodOrderingContext context) 
        {
            _context = context;
        }
        public IRepository<Customer> CustomersRepo 
        {
            get
            {
                return _customersRepo ?? (_customersRepo = new Repository<Customer>(_context));
            }
        }
        public IRepository<Order> OrdersRepo 
        { 
            get
            {
                return _ordersRepo ?? (_ordersRepo = new Repository<Order>(_context));
            }
        }
        public IRepository<OrderItem> OrderItemsRepo 
        {
            get 
            {
                return _orderItemsRepo ?? (_orderItemsRepo = new Repository<OrderItem>(_context));
            }
        }
        public IRepository<Product> ProductsRepo 
        {
            get 
            {
                return _productsRepo ?? (_productsRepo = new Repository<Product>(_context));
            }
        }
        public IRepository<ProductCategory> ProductCategoriesRepo 
        {
            get 
            {
                return _productCategoriesRepo ?? (_productCategoriesRepo = new Repository<ProductCategory>(_context));
            }
        }
        public IRepository<Supplier> SuppliersRepo 
        {
            get 
            {
                return _suppliersRepo ?? (_suppliersRepo = new Repository<Supplier>(_context));
            }
        }

        public void Commit() 
        {
            _context.SaveChanges();
        }
    }
}
