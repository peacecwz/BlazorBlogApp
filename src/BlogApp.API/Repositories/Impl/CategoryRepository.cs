using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.API.Data;
using BlogApp.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApp.API.Repositories.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogAppDbContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(BlogAppDbContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Has error occurred");
                return false;
            }
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.Where(x => x.IsActive && !x.IsDeleted).ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryByIdAsync(int categoryId)
        {
            return await _dbContext.Categories.SingleOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<bool> CreateCategoryAsync(CategoryEntity entity)
        {
            await _dbContext.Categories.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<bool> IsExistCategoryByNameAsync(string name)
        {
            return await _dbContext.Categories.AnyAsync(x => x.Name == name);
        }

        public async Task<bool> UpdateCategoryAsync(CategoryEntity entity)
        {
            _dbContext.Categories.Update(entity);

            return await SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(CategoryEntity entity)
        {
            _dbContext.Categories.Remove(entity);

            return await SaveAsync();
        }

        public async Task<IEnumerable<CategoryEntity>> GetSpotlightCategoriesAsync()
        {
            return await _dbContext.Categories
                .Where(x => x.IsActive && !x.IsDeleted)
                .Where(x => x.IsSpotlight)
                .ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryBySlugAsync(string slug)
        {
            return await _dbContext.Categories
                .Where(category => category.IsActive && !category.IsDeleted)
                .Where(category => category.Slug == slug)
                .FirstOrDefaultAsync();
        }
    }
}