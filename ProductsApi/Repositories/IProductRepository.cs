using DataAccess.Models;
namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
