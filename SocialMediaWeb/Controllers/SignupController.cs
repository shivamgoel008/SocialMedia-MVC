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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User obj)
        {
            if (ModelState.IsValid && obj.confirmPassword == obj.userPassword)
            {
                string passwordhash=BCrypt.Net.BCrypt.HashPassword(obj.userPassword);   
                obj.userPassword= passwordhash;
                obj.confirmPassword = passwordhash;
                _db.Users.Add(obj);
                HttpContext.Session.SetString("userId", obj.Id.ToString());
                HttpContext.Session.SetString("userName", obj.userName.ToString());
                HttpContext.Session.SetString("userEmail", obj.userEmail.ToString());
                _db.SaveChanges();    
                return RedirectToAction("Index", "Home");       
            }

            return RedirectToAction("Index");

        }

    }
}
