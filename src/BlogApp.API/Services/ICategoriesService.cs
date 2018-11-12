using System;
using System.Threading.Tasks;
using BlogApp.Contract.Request.Categories;
using BlogApp.Contract.Response.Categories;

namespace BlogApp.API.Services
{
    public interface ICategoriesService : IDisposable
    {
        Task<GetCategoriesResponse> GetCategoriesAsync(GetCategoriesRequest request);
        Task<GetCategoryResponse> GetCategoryAsync(GetCategoryRequest request);
        Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request);
        Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest request);
        Task<DeleteCategoryResponse> DeleteCategoryAsync(DeleteCategoryRequest request);
    }
}