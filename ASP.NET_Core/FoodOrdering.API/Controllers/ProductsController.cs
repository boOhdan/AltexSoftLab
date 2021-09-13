using FoodOrdering.API.Filters;
using FoodOrdering.DAL.Contracts;
using FoodOrdering.DAL.Models;
using Microsoft.AspNetCore.Mvc;
<<<<<<< Updated upstream
using Microsoft.Extensions.Logging;
=======
using Microsoft.EntityFrameworkCore;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
<<<<<<< Updated upstream
    [Route("[controller]")]
=======
    [Route("api/[controller]")]
    [TypeFilter(typeof(CustomExceptionFilter))]
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        public IEnumerable<Product> Get()
        {
            var products = _unitOfWork.ProductsRepo.Get();
=======
        public ActionResult<IEnumerable<Product>> GetProducts() 
        {
            throw new Exception("Testing custom exception filter.");

            return _unitOfWork.ProductsRepo.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _unitOfWork.ProductsRepo.GetById(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _unitOfWork.ProductsRepo.Update(product);

            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpPost]
        [TypeFilter(typeof(MySampleActionFilter))]
        public ActionResult<Product> CreateProduct(Product product)
        {
            var pr = product;

            _unitOfWork.ProductsRepo.Insert(product);
            _unitOfWork.Commit();

            return CreatedAtAction( 
                nameof(GetProduct), 
                new { id = product.ProductId },
                product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductsRepo.GetById(id);

            if (product is null)
            {
                return NotFound();
            }

            _unitOfWork.ProductsRepo.Delete(product);
            _unitOfWork.Commit();
>>>>>>> Stashed changes

            return products;
        }

        //GET /api/products
        //GET /api/products/{id}
        //POST /api/products
        //PUT /api/products/{id}
        //DELETE /api/products/{id}
    }
}

