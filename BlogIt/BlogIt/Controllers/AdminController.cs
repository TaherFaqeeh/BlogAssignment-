using BlogIt.Services;
using System.Linq;
using System.Web.Mvc;

namespace BlogIt.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDataContext _dataContext;
        public AdminController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        /// <summary>
        /// Gets admin page
        /// </summary>
        public ActionResult Index()
        {
            var blogs = _dataContext.GetBlogs().ToList();
            return View(blogs);
        }
    }
}