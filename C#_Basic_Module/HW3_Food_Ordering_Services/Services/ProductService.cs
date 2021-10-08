using FoodOrdering.BLL.Contracts;
using FoodOrdering.DAL.Contracts;
using FoodOrdering.DAL.Models;
using System.Collections.Generic;

namespace FoodOrdering.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> Get() => 
            _unitOfWork.ProductsRepo.Get();


        public Product GetById(int id) =>
            _unitOfWork.ProductsRepo.GetById(id);
        

        public void Insert(Product product) =>
            _unitOfWork.ProductsRepo.Insert(product);
        

        public void Delete(int id) =>
            _unitOfWork.ProductsRepo.Delete(id);
        

        public void Delete(Product product) =>
            _unitOfWork.ProductsRepo.Delete(product);

        public void Update(Product product) =>
            _unitOfWork.ProductsRepo.Update(product);

        public void Save() => 
            _unitOfWork.Commit();
    }
}
