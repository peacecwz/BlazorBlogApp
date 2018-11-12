using BlogApp.API.Data.Entities;
using BlogApp.Contract.Models;

namespace BlogApp.API.Mappers
{
    public interface ICategoryMapper : IMapper<CategoryEntity, CategoryModel>
    {
    }
}