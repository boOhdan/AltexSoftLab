using FoodOrdering.DAL.Contracts;
using FoodOrdering.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() =>
            _unitOfWork.ProductsRepo.Get().ToList();


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
        public ActionResult<Product> CreateProduct(Product product)
        {
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

            return NoContent();
        }

        private bool ProductExists(int id) =>
            _unitOfWork.ProductsRepo.Get().Any(e => e.ProductId == id);
    }
}

