using BlogIt.Services;
using System.Linq;
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

        /// <summary>
        /// Show the lastest two blogs on the home page
        /// </summary>
        public ActionResult Index()
        {
            var blogs = _dataContext.GetBlogs().Take(2).ToList();
            ViewBag.Message = "Our Latest Blogs";
            return View(blogs);
        }

        /// <summary>
        /// Get about page
        /// </summary>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Get contact page
        /// </summary>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Get blogs page
        /// </summary>
        public ActionResult Blogs()
        {
            var blogs = _dataContext.GetBlogs().ToList();

            ViewBag.Message = "All The New Blogs.";

            return View(blogs);
        }
    }
}