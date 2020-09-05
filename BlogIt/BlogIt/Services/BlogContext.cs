using BlogIt.Models;
using System;
using System.Data.Entity;
using BlogIt.Services;

namespace BlogIt.Services
{
    public class BlogContext : IDataContext
    {
        private readonly BlogDbContext _db;

        public BlogContext(BlogDbContext db)
        {
            _db = db;
        }
        public DbSet<Blog> GetBlogs()
        {
            return _db.Blogs;
        }

        public DbContext GetDbContexts()
        {
            return this._db;
        }

        public DbSet<User> GetUsers()
        {
            return _db.Users;
        }
    }
}
