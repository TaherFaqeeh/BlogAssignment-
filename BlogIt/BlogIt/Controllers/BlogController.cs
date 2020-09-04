using BlogIt.DataModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogIt.Controllers
{
    public class BlogController : Controller
    {
        private readonly IDataContext _dataContext;

        public BlogController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: Blog
        public ActionResult Details(int id)
        {
            var blog = _dataContext.GetBlogs().FirstOrDefault(e => e.Id == id);
            return View(blog);
        }
    }
}