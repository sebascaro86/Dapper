using Dapper.API.Core.Entities;
using Dapper.API.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _productRepository.GetById(id);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Product product)
        {
            return Ok(await _productRepository.Create(product));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Product product)
        {
            var currentProduct = await _productRepository.GetById(product.Id);
            if (currentProduct == null)
            {
                return BadRequest("Product to update not found");
            }

            return Ok(await _productRepository.Update(product));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var currentProduct = await _productRepository.GetById(id);
            if (currentProduct == null)
            {
                return BadRequest("Product to delete not found");
            }

            return Ok(await _productRepository.Delete(id));
        }
    }
}
