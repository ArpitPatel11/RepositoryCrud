using PracticeApp.Models;

namespace PracticeApp.Repository
{
    public interface IProductServices
    {
        public Task<List<Category>> GetCategoryListAsync();
        public Task <int> AddCategoryAsync(Category category);
        public Task<int> UpdateCategoryAsync(Category category);
        public Task<int> DeleteCategoryAsync(int id);




        public Task<List<Product>> GetProductListAsync();
        public Task<int> AddProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int id);

    }
}
