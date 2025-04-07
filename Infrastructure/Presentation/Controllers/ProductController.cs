using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Absraction;
using Shared;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager) 
        {
            _serviceManager = serviceManager;
        }
        //Get All Products [EndPoints]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProducts(string? sort, int? brandId, int? typeId)
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync(sort , brandId , typeId);
            return Ok(products);
        }
        //Get All Brands [EndPoints]
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
        {
            var brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }
        //Get All Types [EndPoints]
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
        {
            var types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }
        //Get Product By Id [EndPoints]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }
}
