using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeApp.Models;
using PracticeApp.Repository;
using System.Numerics;

namespace PracticeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetProductListAsync()
        {
            try
            {
                return await _productService.GetProductListAsync();
            }
            catch
            {
                throw;
            }
        }
        //public async Task<IEnumerable<Product>> Get()
        //{
        //    return await _productService.GetProductListAsync();
        //}

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _productService.AddProductAsync(product);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _productService.UpdateProductAsync(product);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<int> DeleteProductAsync(int Id)
        {
            try
            {
                var response = await _productService.DeleteProductAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }


        }

    }
}
