using Microsoft.AspNetCore.Mvc;
using myShop.DataAccess.Data;
using myShop.Entities.Models;

namespace myShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) 
            {
                return NotFound();
            }
            var category = _context.Categories.FirstOrDefault(c => c.Id == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.FirstOrDefault(c => c.Id == Id);

            return View(category);
        }
        [HttpPost]
        public IActionResult DeleteCategory(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.FirstOrDefault(c => c.Id == Id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
