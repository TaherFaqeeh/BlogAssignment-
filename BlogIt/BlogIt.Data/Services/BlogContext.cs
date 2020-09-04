using BlogIt.DataModel.Models;
using System;
using System.Data.Entity;
using BlogIt.DataModel.Services;

namespace BlogIt.DataModel.Services
{
    public class BlogContext : IDataContext
    {
        private readonly BlogDbContext _db;

        public BlogContext(BlogDbContext db)
        {
            _db = new BlogDbContext();
        }
        public DbSet<Blog> GetBlogs()
        {
            return _db.Blogs;
        }

        public DbContext GetDbContexts()
        {
            return _db.DbContexts;
        }
    }
}
