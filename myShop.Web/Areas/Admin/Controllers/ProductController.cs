using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myShop.DataAccess.Data;
using myShop.Entities.Models;
using myShop.Entities.Repositories;
using myShop.Entities.ViewModels;
namespace myShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private  readonly IunitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IunitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                product = new Product(),
                CategoryList=_unitOfWork.Category.GetAll().Select(x=>new SelectListItem()
                {
                    Text= x.Name,
                    Value=x.Id.ToString()
                })
            };

            return View(productViewModel);
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
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) 
            {
                return NotFound();
            }
            Product product=_unitOfWork.Product.GetFirstOrDefault(x=>x.Id==Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Complete();
                TempData["Update"] = "Data Has Updated Successfully";

                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == Id);

            return View(product);
        }
        [HttpPost]
        public IActionResult DeleteProduct(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == Id);
            if (product != null)
            {
                _unitOfWork.Product.Remove(product);
                _unitOfWork.Complete();
                TempData["Delete"] = "Data Has Deleted Successfully";

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
