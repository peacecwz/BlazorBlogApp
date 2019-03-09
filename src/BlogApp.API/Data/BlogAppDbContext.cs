using BlogApp.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Data
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
    }
}