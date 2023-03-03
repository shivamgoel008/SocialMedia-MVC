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
        public IActionResult SignupPage()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(User obj)
        {
            
            
            if (ModelState.IsValid && obj.confirmPassword==obj.userPassword)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();    /*at this point data goes to database and saves all the changes  */
                return RedirectToAction("Index", "Home");        /*once changes are saved we return the view*/
            } 
            
            return RedirectToAction("SignupPage");

        }

    }
}
