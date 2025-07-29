using myShop.Entities.Models;

namespace myShop.Entities.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void Update(Product product);
    }
}
