using backend.DTOs;

namespace backend.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> AddAsync(CreateProductDto dto);
    }
}
