using backend.Data;
using backend.Models;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}