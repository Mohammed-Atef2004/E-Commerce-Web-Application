using Microsoft.AspNetCore.Mvc;
using myShop.DataAccess.Data;
using myShop.Entities.Models;
using myShop.Entities.Repositories;
namespace myShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private  IunitOfWork _unitOfWork;
        public CategoryController(IunitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();
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
               _unitOfWork.Category.Add(category);
                _unitOfWork.Complete();
                TempData["Create"] = "Data Has Created Successfully";
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
            Category category=_unitOfWork.Category.GetFirstOrDefault(x=>x.Id==Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Complete();
                TempData["Update"] = "Data Has Updated Successfully";

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
            Category category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == Id);

            return View(category);
        }
        [HttpPost]
        public IActionResult DeleteCategory(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == Id);
            if (category != null)
            {
                _unitOfWork.Category.Remove(category);
                _unitOfWork.Complete();
                TempData["Delete"] = "Data Has Deleted Successfully";

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
