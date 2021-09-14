using FoodOrdering.DAL.Contracts;
using FoodOrdering.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.API.Controllers
{
    public class ProductsMvcController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsMvcController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.ProductsRepo.Get(includeProperties: "Supplier,ProductCategory"));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int? id, Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductsRepo.Insert(product);
                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [ResponseCache(VaryByHeader = "Accept-Encoding", Duration = 120)]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var product = _unitOfWork.ProductsRepo.GetById(id);

            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var product = _unitOfWork.ProductsRepo.GetById(id);

            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductsRepo.Update(product);
                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var product = _unitOfWork.ProductsRepo.GetById(id);

            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.ProductsRepo.GetById(id);

            _unitOfWork.ProductsRepo.Delete(product);
            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }
    }
}