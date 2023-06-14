using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Models;

namespace PracticeApp.Repository
{
    public class ProductService : IProductServices
    {

        private readonly DataContext _dbContext;

        public ProductService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Category>> GetCategoryListAsync()
        {
            return _dbContext.Categories
                .FromSqlRaw<Category>("USP_Category_Get")
                .ToListAsync();
        }

        public Task<int> AddCategoryAsync(Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));

            var result = Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec USP_Category_Insert @CategoryName", parameter.ToArray()));

            return result;
        }

        public Task<int> UpdateCategoryAsync(Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", category.CategoryId));
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));

            var result = Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec USP_Category_Update 
                                @CategoryId, @CategoryName", parameter.ToArray()));
            return result;
        }

        public Task<int> DeleteCategoryAsync(int id)
        {
            return Task.Run(() => _dbContext.Database
                    .ExecuteSqlInterpolatedAsync($"USP_Category_Delete {id}"));
        }



        public Task<List<Product>> GetProductListAsync()
        {
            return _dbContext.Products
               .FromSqlRaw<Product>("USP_Product_Get")
               .ToListAsync();
        }

        public Task<int> AddProductAsync(Product product)
        {
            var parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@ProductName", product.CategoryId));
            parameter.Add(new SqlParameter("@ProductPrice", product.CategoryId));
            parameter.Add(new SqlParameter("@CategoryId", product.CategoryId));


            var result = Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec USP_Product_Insert @ProductName,@ProductPrice,@CategoryId", parameter.ToArray()));

            return result;
        }

        public Task<int> UpdateProductAsync(Product product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", product.CategoryId));
            parameter.Add(new SqlParameter("@ProductId", product.ProductId));
            parameter.Add(new SqlParameter("@ProductName", product.ProductName));
            parameter.Add(new SqlParameter("@ProductPrice", product.ProductPrice));


            var result = Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec USP_Product_Update 
                                @CategoryId, @ProductId , @ProductName , @ProductPrice", parameter.ToArray()));
            return result;
        }

        public Task<int> DeleteProductAsync(int id)
        {
            return Task.Run(() => _dbContext.Database
                   .ExecuteSqlInterpolatedAsync($"USP_Product_Delete {id}"));
        }
    }
}
