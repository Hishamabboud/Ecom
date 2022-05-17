using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IConfiguration configuration, IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _configuration = configuration;
            _productRepository = productRepository;
            _logger = logger;
            
        }

        [HttpPost]
        public async Task<Product> Create(Product product)
        {
            return await _productRepository.Create(product);
        }

        [HttpPut]
        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        [HttpDelete]
        public async Task Delete(Product product)
        {
            await _productRepository.Delete(product);
        }
    }
}