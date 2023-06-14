using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeApp.Models;
using PracticeApp.Repository;

namespace PracticeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProductServices _productService;

        public CategoryController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
       
        public async Task<List<Category>> GetCategoryListAsync()
        {
            try
            {
                return await _productService.GetCategoryListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _productService.AddCategoryAsync(category);

                return Ok(category);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _productService.UpdateCategoryAsync(category);
                return Ok(category);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<int> DeleteCategoryAsync(int Id)
        {
            try
            {
                var response = await _productService.DeleteCategoryAsync(Id);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }


        }





    }
}
