using myShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShop.Entities.ViewModels
{
    public class productWithCountViewModel
    {
        public Product Product { get; set; }
        public int count { get; set; }
    }
}
