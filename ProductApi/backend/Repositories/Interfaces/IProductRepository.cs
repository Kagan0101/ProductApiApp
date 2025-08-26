using backend.Models;

namespace backend.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
    }
}
