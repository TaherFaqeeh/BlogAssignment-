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
            var z = _dataContext.GetUsers().ToList();
            string messsage = "";
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
                else
                {
                    messsage = "Invalid Request";
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


            ViewBag.Message = messsage;
            return RedirectToAction("Index","Home",null);
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
        ActionResult Login(string Email, string Password)
        {
            if (Email != null && Password != null)
            {
                var obj = _dataContext.GetUsers().FirstOrDefault(e => e.Email.Equals(Email) && e.Password == Password);

                if (obj != null)
                {
                    Session["Email"] = obj.Email.ToString();
                    Session["UserId"] = obj.Id.ToString();
                }
            }
            return View();
        }

    }
}