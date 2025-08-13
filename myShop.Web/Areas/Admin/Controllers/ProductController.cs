
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myShop.DataAccess;
using myShop.Entities.Models;
using myShop.Entities.Repositories;
using myShop.Entities.ViewModels;
namespace myshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IunitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IunitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var categories = _unitOfWork.Product.GetAll(includeword: "Category");
            return Json(new { data = categories });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel productVM = new ProductViewModel()
            {
                product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productVM, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string RootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var Upload = Path.Combine(RootPath, @"Images\Products");
                    var ext = Path.GetExtension(file.FileName);

                    using (var filestream = new FileStream(Path.Combine(Upload, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    productVM.product.Img = @"Images\Products\" + filename + ext;
                }

                _unitOfWork.Product.Add(productVM.product);
                _unitOfWork.Complete();
                TempData["Create"] = "Item has Created Successfully";
                return RedirectToAction("Index");
            }
            return View(productVM.product);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }

            ProductViewModel productVM = new ProductViewModel()
            {
                product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _webHostEnvironment.WebRootPath;

                // Get the original product from the database
                var productFromDb = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == productVM.product.Id);

                if (productFromDb == null)
                {
                    return NotFound();
                }

                // Update scalar fields from the posted model
                productFromDb.Name = productVM.product.Name;
                productFromDb.Description = productVM.product.Description;
                productFromDb.Price = productVM.product.Price;
                productFromDb.CategoryId = productVM.product.CategoryId;
                // Add any other fields you want to update...

                if (file != null)
                {
                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(productFromDb.Img))
                    {
                        var oldImagePath = Path.Combine(rootPath, productFromDb.Img.TrimStart('\\', '/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Save new image
                    string fileName = Guid.NewGuid().ToString();
                    var uploadFolder = Path.Combine(rootPath, "Images", "Products");
                    var extension = Path.GetExtension(file.FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploadFolder, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productFromDb.Img = Path.Combine("Images", "Products", fileName + extension);
                }

                _unitOfWork.Product.Update(productFromDb);
                _unitOfWork.Complete();

                TempData["Update"] = "Data has been updated successfully";
                return RedirectToAction("Index");
            }

            return View(productVM);
        }



        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productIndb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            if (productIndb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.Product.Remove(productIndb);
            var oldimg = Path.Combine(_webHostEnvironment.WebRootPath, productIndb.Img.TrimStart('\\'));
            if (System.IO.File.Exists(oldimg))
            {
                System.IO.File.Delete(oldimg);
            }
            _unitOfWork.Complete();
            return Json(new { success = true, message = "file has been Deleted" });
        }
    }
}
