using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApp.API.Data.Entities;

namespace BlogApp.API.Repositories
{
    public interface IPostRepository : IRepository
    {
        Task<IEnumerable<PostEntity>> GetPostsAsync(int pageIndex, int itemCountPerPage);
        Task<PostEntity> GetPostByIdAsync(Guid postId);
        Task<PostEntity> GetPostBySlugAsync(string slug);
        Task<bool> IsExistsPostByTitleAsync(string title);
        Task<bool> CreatePostAsync(PostEntity entity);
        Task<bool> UpdatePostAsync(PostEntity entity);
        Task<bool> DeletePostAsync(PostEntity entity);
    }
}