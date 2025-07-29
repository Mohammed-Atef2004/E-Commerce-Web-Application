using myShop.DataAccess.Data;
using myShop.Entities.Models;
using myShop.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShop.DataAccess.Implementation
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Product product)
        {
            var productindb=_context.Products.FirstOrDefault(x=>x.Id == product.Id);
            if (productindb != null)
            {
                productindb.Name = product.Name;
                productindb.Description = product.Description;
                productindb.Price = product.Price;
                productindb.Category = product.Category;
            }
        }

       
    }
}
