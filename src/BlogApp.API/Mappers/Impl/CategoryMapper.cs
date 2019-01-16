using BlogApp.API.Data.Entities;
using BlogApp.Contract.Models;

namespace BlogApp.API.Mappers.Impl
{
    public class CategoryMapper : ICategoryMapper
    {
        public CategoryEntity ToEntity(CategoryModel model)
        {
            return new CategoryEntity()
            {
                Id = model.Id,
                Name = model.Name,
                IsSpotlight = model.IsSpotlight,
                Slug = model.Slug
            };
        }

        public CategoryModel ToModel(CategoryEntity entity)
        {
            return new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsSpotlight = entity.IsSpotlight,
                Slug = entity.Slug
            };
        }
    }
}