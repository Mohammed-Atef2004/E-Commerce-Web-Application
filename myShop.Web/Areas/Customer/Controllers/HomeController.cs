using Microsoft.AspNetCore.Mvc;
using myShop.Entities.Repositories;
using myShop.Entities.ViewModels;

namespace myShop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IunitOfWork _unitOfWork;
        public HomeController(IunitOfWork unintOfWork)
        {
            _unitOfWork = unintOfWork;
        }
        public IActionResult Index()
        {
            var results = _unitOfWork.Product.GetAll();
            return View(results);
        }
        public IActionResult Details(int ProductId)
        {
            productWithCountViewModel productWithCount = new productWithCountViewModel()
            {
                Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == ProductId, includeword: "Category"),
                count = 1
            };
            return View(productWithCount);
        }
    }
}
