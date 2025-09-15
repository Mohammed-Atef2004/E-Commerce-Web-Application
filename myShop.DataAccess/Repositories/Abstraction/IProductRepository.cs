using myShop.DAL.Models;

namespace myShop.DAL.Repositories.Abstraction
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void Update(Product product);
    }
}
