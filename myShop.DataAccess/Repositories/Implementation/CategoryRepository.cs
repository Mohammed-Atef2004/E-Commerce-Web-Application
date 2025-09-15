using myShop.DAL.Data;
using myShop.DAL.Models;
using myShop.DAL.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Category category)
        {
            var categoryindb=_context.Categories.FirstOrDefault(x=>x.Id == category.Id);
            if (categoryindb != null)
            {
                categoryindb.Name = category.Name;
                categoryindb.CreatedTime = DateTime.Now;
                categoryindb.Description = category.Description;
            }
        }

    }
}
