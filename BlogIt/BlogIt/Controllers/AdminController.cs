using BlogIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogIt.Controllers
{
    public class AdminController : Controller
    {
        private IDataContext _dataContext;
        public AdminController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: Admin
        public ActionResult Index()
        {
            var blogs = _dataContext.GetBlogs().ToList();
            return View(blogs);
        }
    }
}