using FoodOrdering.API.Filters;
using FoodOrdering.DAL.Contracts;
using FoodOrdering.BLL.Contracts;
using FoodOrdering.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() =>
            _productService.Get().ToList();

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetById(id);


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

            _productService.Update(product);

            try
            {
                _productService.Save();
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
        [TypeFilter(typeof(CustomActionFilter))]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _productService.Insert(product);
            _productService.Save();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.ProductId },
                product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetById(id);

            if (product is null)
            {
                return NotFound();
            }

            _productService.Delete(product);
            _productService.Save();

            return NoContent();
        }

        private bool ProductExists(int id) =>
            _productService.Get().Any(e => e.ProductId == id);
    }
}