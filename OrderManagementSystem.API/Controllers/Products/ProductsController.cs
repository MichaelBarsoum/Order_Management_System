using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Management_System.CORE.Contracts;
using Order_Management_System.Repositories.Models;
using OrderManagementSystem.API.DTOs.Product;
using OrderManagementSystem.API.Errors;

namespace OrderManagementSystem.API.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> ProductRepo, IMapper mapper)
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
        }

        // GET /api/products - Get all products
        [HttpGet]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            var products = await _productRepo.GetAllAsync();
            if (products is null) return NotFound(new ApiErrorResponse(404, "No Products Found"));
            return Ok(products);
        }

        // GET /api/products/{productId} - Get details of a specific product

        [HttpGet("productId")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById([FromQuery]int productId)
        {
            var product = await _productRepo.GetByIdAsync(productId);
            if (product is null) return NotFound(new ApiErrorResponse(404, $" Product With ID : {productId} Not Found !"));
            return Ok(product);
        }

        // POST /api/products - Add a new product (admin only)

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddNewProduct(ProductDTO product)
        {
            if (product is null) return BadRequest(new ApiErrorResponse(400));
            var MappedProduct = _mapper.Map<Product>(product);
            if (MappedProduct is null) return BadRequest(new ApiErrorResponse(400));
            await _productRepo.CreateAsync(MappedProduct);
            return Ok(MappedProduct);
        }

        // PUT /api/products/{productId} - Update product details (admin only)

        [Authorize(Roles = "Admin")]
        [HttpPut("{productId}")]
        public async Task<ActionResult<Product>> UpdateProduct([FromQuery] int productId,[FromBody] ProductDTO model)
        {
            var product = await _productRepo.GetByIdAsync(productId);
            if (product is null) return NotFound(new ApiErrorResponse(404));
            product.Price = model.Price;
            product.Name = model.Name;
            var MappedProduct = _mapper.Map<Product>(product);
            await _productRepo.UpdateAsync(MappedProduct);
            return Ok(product);
        }
    }
}
