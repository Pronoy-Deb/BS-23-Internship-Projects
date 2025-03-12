using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management_Application.Data;
using Product_Management_Application.Models;

namespace Product_Management_Application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext _dbContext;

        public ProductsController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products.ToListAsync(); // Fetch all products
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

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "The product has been added successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

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

            _dbContext.Update(product);
            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "The product details have been updated successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "The product has been deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Product_Management_Application.Data;
//using Product_Management_Application.Models;

//namespace Product_Management_Application.Controllers
//{
//    public class ProductsController : Controller
//    {
//        //private static List<Product> Lproducts = new List<Product>();
//        private readonly ProductDbContext _dbContext;

//        //[HttpPost]
//        //public IActionResult CreateProduct([FromBody] Product product)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    Lproducts.Add(product);
//        //    return Ok(product);
//        //}

//        public ProductsController(ProductDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public async Task<IActionResult> Index()
//        {
//            var products = await _dbContext.Products.ToListAsync(); // Fetch all products
//            return View(products);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Product product)
//        {
//            await _dbContext.Products.AddAsync(product);
//            await _dbContext.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }
//        public async Task<IActionResult> Edit(int id)
//        {
//            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

//            if (product == null)
//            {
//                return NotFound(id);
//            }

//            return View(product);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(Product product)
//        {
//            _dbContext.Update(product);
//            await _dbContext.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            var emplotee = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

//            if (emplotee == null)
//            {
//                return NotFound(id);
//            }

//            _dbContext.Products.Remove(emplotee);

//            await _dbContext.SaveChangesAsync();

//            return RedirectToAction("Index");
//        }

//    }
//}
