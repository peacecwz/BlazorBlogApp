using System;
using System.Threading.Tasks;
using BlogApp.Contract.Request.Posts;
using BlogApp.Contract.Response.Posts;

namespace BlogApp.API.Services
{
    public interface IPostsService : IDisposable
    {
        Task<GetPostsResponse> GetPostsAsync(GetPostsRequest request);
        Task<GetPostResponse> GetPostAsync(GetPostRequest request);
        Task<CreatePostResponse> CreatePostAsync(CreatePostRequest request);
        Task<UpdatePostResponse> UpdatePostAsync(UpdatePostRequest request);
        Task<DeletePostResponse> DeletePostAsync(DeletePostRequest request);
    }
}