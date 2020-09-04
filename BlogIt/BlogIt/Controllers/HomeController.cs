using BlogIt.DataModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataContext _dataContext;
        public HomeController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ActionResult Index()
        {
            var blogs = _dataContext.GetBlogs().Take(2).ToList();
            ViewBag.Message = "Our Latest Blogs";
            return View(blogs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blogs()
        {
            var blogs = _dataContext.GetBlogs().ToList();

            ViewBag.Message = "All The New Blogs.";

            return View(blogs);
        }
    }
}