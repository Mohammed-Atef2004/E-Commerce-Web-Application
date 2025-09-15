using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using myShop.DAL.Models;
namespace myShop.DAL.ViewModels
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
