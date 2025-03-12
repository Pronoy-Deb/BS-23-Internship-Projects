using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management_Application.Data;
using Product_Management_Application.Models;
using Product_Management_Application.Repository;

namespace Product_Management_Application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository<Product> _productRepository;

        public ProductsController(IProductRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync(); // Fetch all products
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _productRepository.AddAsync(product);

            TempData["SuccessMessage"] = "The product has been added successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _productRepository.UpdateAsync(product);

            TempData["SuccessMessage"] = "The product details have been updated successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _productRepository.DeleteAsync(product);

            TempData["SuccessMessage"] = "The product has been deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}