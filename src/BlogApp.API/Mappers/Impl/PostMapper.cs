using BlogApp.API.Data.Entities;
using BlogApp.Contract.Models;

namespace BlogApp.API.Mappers.Impl
{
    public class PostMapper : IPostMapper
    {
        public PostEntity ToEntity(PostModel model)
        {
            return new PostEntity()
            {
                Id =  model.PostId,
                Title = model.Title,
                Slug = model.Slug,
                Description = model.Description,
                Content = model.Content,
                ContentType = model.ContentType,
                CategoryId = model.CategoryId,
                Tags = model.Tags,
                CoverImageUrl = model.CoverIamgeUrl,
                CreatedOn = model.CreatedOn,
                PublishedDate = model.PublishedDate,
                AuthorId = model.AuthorId
            };
        }

        public PostModel ToModel(PostEntity entity)
        {
            return new PostModel()
            {
                Slug = entity.Slug,
                Title = entity.Title,
                PostId = entity.Id,
                CategoryId = entity.CategoryId,
                CreatedOn = entity.CreatedOn,
                PublishedDate = entity.PublishedDate,
                AuthorId = entity.AuthorId,
                Content = entity.Content,
                ContentType = entity.ContentType,
                CoverIamgeUrl = entity.CoverImageUrl,
                Description = entity.Description,
                Tags = entity.Tags
            };
        }
    }
}