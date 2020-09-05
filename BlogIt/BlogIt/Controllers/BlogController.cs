using BlogIt.Services;
using System.Linq;
using System.Web.Mvc;
using BlogIt.Models;
using System.Data.Entity;

namespace BlogIt.Controllers
{
    public class BlogController : Controller
    {
        private readonly IDataContext _dataContext;

        public BlogController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ActionResult Index()
        {
            var blogs = _dataContext.GetBlogs().ToList();
            return View(blogs);
        }

        /// <summary>
        /// Show Blog details
        /// </summary>
        public ActionResult Details(int id)
        {
            var blog = _dataContext.GetBlogs().FirstOrDefault(e => e.Id == id);
            return View(blog);
        }

        /// <summary>
        /// Create blog
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Submit action for creating a blog
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var userId = Session["UserId"].ToString();
                if (!string.IsNullOrEmpty(userId))
                {
                    blog.UserId = int.Parse(userId);
                }
                else
                {
                    ViewBag.error = "Error Creating New Blog";
                    return RedirectToAction("Create");
                }

                _dataContext.GetBlogs().Add(blog);
                _dataContext.GetDbContexts().SaveChanges();

            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Modify blog
        /// </summary>
        public ActionResult Modify(int id)
        {
            var blog = _dataContext.GetBlogs().FirstOrDefault(e => e.Id == id);
            return View(blog);
        }

        /// <summary>
        /// Submit action for editing a blog
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _dataContext.GetDbContexts().Entry(blog).State = EntityState.Modified;
                _dataContext.GetDbContexts().SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}