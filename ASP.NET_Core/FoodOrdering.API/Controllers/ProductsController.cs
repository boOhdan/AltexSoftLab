using FoodOrdering.DAL.Contracts;
using FoodOrdering.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _unitOfWork.ProductsRepo.Get();

            return products;
        }

        //GET /api/products
        //GET /api/products/{id}
        //POST /api/products
        //PUT /api/products/{id}
        //DELETE /api/products/{id}
    }
}

