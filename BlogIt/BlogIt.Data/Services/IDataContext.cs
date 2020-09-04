using BlogIt.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogIt.DataModel.Services
{
    public interface IDataContext
    {
        DbSet<Blog> GetBlogs();
        DbContext GetDbContexts();
        DbSet<User> GetUsers();
    }
}
