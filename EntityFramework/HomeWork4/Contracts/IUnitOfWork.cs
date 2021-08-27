using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomersRepo { get; }
        IRepository<Order> OrdersRepo { get; }
        IRepository<OrderItem> OrderItemsRepo { get; }
        IRepository<Product> ProductsRepo { get; }
        IRepository<ProductCategory> ProductCategoriesRepo { get; }
        IRepository<Supplier> SuppliersRepo { get; }
        void Commit();
    }
}
