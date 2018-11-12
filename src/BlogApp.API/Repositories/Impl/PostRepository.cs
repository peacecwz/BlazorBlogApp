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
    public class PostRepository : IPostRepository
    {
        private readonly BlogAppDbContext _dbContext;
        private readonly ILogger<PostRepository> _logger;
        public PostRepository(BlogAppDbContext dbContext, ILogger<PostRepository> logger)
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
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);
                return false;
            }
        }

        public async Task<IEnumerable<PostEntity>> GetPostsAsync(int pageIndex, int itemCountPerPage)
        {
            return await _dbContext.Posts
                .OrderByDescending(x => x.CreatedOn)
                .Skip(pageIndex * itemCountPerPage)
                .Take(itemCountPerPage)
                .ToListAsync();
        }

        public async Task<PostEntity> GetPostByIdAsync(Guid postId)
        {
            return await _dbContext.Posts.FindAsync(postId);
        }

        public async Task<PostEntity> GetPostBySlugAsync(string slug)
        {
            return await _dbContext.Posts.SingleOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task<bool> IsExistsPostByTitleAsync(string title)
        {
            return await _dbContext.Posts.AnyAsync(x => x.Title == title);
        }

        public async Task<bool> CreatePostAsync(PostEntity entity)
        {
            await _dbContext.Posts.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<bool> UpdatePostAsync(PostEntity entity)
        {
            _dbContext.Posts.Update(entity);

            return await SaveAsync();
        }

        public async Task<bool> DeletePostAsync(PostEntity entity)
        {
            _dbContext.Posts.Remove(entity);

            return await SaveAsync();
        }
    }
}