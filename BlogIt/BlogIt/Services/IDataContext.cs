using BlogIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogIt.Services
{
    public interface IDataContext
    {
        DbSet<Blog> GetBlogs();
        DbContext GetDbContexts();
        DbSet<User> GetUsers();
    }
}
