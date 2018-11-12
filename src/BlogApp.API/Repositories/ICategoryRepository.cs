using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApp.API.Data.Entities;

namespace BlogApp.API.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task<CategoryEntity> GetCategoryByIdAsync(int categoryId);
        Task<bool> CreateCategoryAsync(CategoryEntity entity);
        Task<bool> IsExistCategoryByNameAsync(string name);
        Task<bool> UpdateCategoryAsync(CategoryEntity entity);
        Task<bool> DeleteCategoryAsync(CategoryEntity entity);
    }
}