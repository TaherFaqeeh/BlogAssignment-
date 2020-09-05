using BlogIt.Models;
using BlogIt.Services;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace BlogIt.Controllers
{
    public class UsersController : Controller
    {
        private readonly IDataContext _dataContext;
        BlogDbContext db = new BlogDbContext();
        public UsersController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = IsEmailExist(user.Email);
                    if (isExist)
                    {
                        ModelState.AddModelError("EmailExist", "Email already exist");
                        return View(user);
                    }

                    _dataContext.GetUsers().Add(user);
                    _dataContext.GetDbContexts().SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            ViewBag.erorr = "Invalid Request";
            return RedirectToAction("Index", "Home", null);
        }

        public bool IsEmailExist(string email)
        {
            var x = _dataContext.GetUsers().FirstOrDefault(e => e.Email == email);
            return x != null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataContext.GetDbContexts().Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            if (Email != null && Password != null)
            {
                var obj = _dataContext.GetUsers().FirstOrDefault(e => e.Email.Equals(Email) && e.Password == Password);

                if (obj != null)
                {
                    Session["Email"] = obj.Email.ToString();
                    Session["UserId"] = obj.Id.ToString();
                    Session["First Name"] = obj.FirstName.ToString();

                    if (obj.Email == "Admin@blog.com")
                    {
                        return RedirectToAction("Index", "Admin", null);
                    }
                    else
                    {
                        return RedirectToAction("Index",new {id = obj.Id});
                    }
                }
                else
                {
                    ViewBag.error = "Faild to login";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ViewBag.error = "Faild to login";
                return RedirectToAction("Login");
            }
        }

        public ActionResult Index(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                if (Session["UserId"] != null)
                {
                    id = int.Parse(Session["UserId"].ToString());
                }
            }
            var blog = _dataContext.GetBlogs()?.Where(e => e.UserId == id).ToList();
            return View(blog);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home",null);
        }

    }
}