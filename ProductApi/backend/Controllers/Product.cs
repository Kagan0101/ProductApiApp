using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using backend.DTOs;
using backend.Services.Interfaces;

namespace backend.Controllers   
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase   
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)   
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto dto)
            => Ok(await _service.AddAsync(dto));
    }
}
