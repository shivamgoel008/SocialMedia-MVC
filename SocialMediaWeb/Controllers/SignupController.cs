using Microsoft.AspNetCore.Mvc;
using SocialMediaWeb.Data;
using SocialMediaWeb.Models;

namespace SocialMediaWeb.Controllers
{
    public class SignupController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SignupController(ApplicationDbContext db)
        {
            _db = db;// now we can use this _db to retrive all the categories 
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("userId");
            if (userId != null)
            {
                return RedirectToAction("Index", "Post");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User obj)
        {
            if (ModelState.IsValid && obj.confirmPassword == obj.userPassword)
            {
                TempData["success"] = "User created successfully . Please login to continue";
                string passwordhash = BCrypt.Net.BCrypt.HashPassword(obj.userPassword);
                obj.userPassword = passwordhash;
                obj.confirmPassword = passwordhash;
                _db.Users.Add(obj);
                _db.SaveChanges();
               
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
