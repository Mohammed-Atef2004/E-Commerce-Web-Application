using myShop.DAL.Models;

namespace myShop.DAL.Repositories.Abstraction
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        void Update(Category category);
    }
}
