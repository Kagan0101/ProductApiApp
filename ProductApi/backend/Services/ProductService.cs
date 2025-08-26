using backend.DTOs;
using backend.Models;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }

        public async Task<ProductDto> AddAsync(CreateProductDto dto)
        {
            var product = new Product { Name = dto.Name, Price = dto.Price };
            var created = await _repo.AddAsync(product);

            return new ProductDto
            {
                Id = created.Id,
                Name = created.Name,
                Price = created.Price
            };
        }
    }
}
