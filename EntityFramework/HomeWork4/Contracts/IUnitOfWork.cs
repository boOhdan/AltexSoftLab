using FoodOrdering.DAL.Models;

namespace FoodOrdering.DAL.Contracts
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
