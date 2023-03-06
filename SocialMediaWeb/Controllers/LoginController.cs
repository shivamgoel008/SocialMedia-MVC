using Microsoft.AspNetCore.Mvc;
using SocialMediaWeb.Data;
using SocialMediaWeb.Models;
using System.ComponentModel;

namespace SocialMediaWeb.Controllers
{

    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost , ActionName("Index")]
        [ValidateAntiForgeryToken]
        public IActionResult IndexUser(User obj )
        {
            var user = _db.Users.Where(m => m.userEmail == obj.userEmail );
            if (user.Any())
            {
                if (BCrypt.Net.BCrypt.Verify(obj.userPassword, user.ToList()[0].userPassword ) )
                {
                    HttpContext.Session.SetString("userId", user.ToList()[0].Id.ToString());
                    HttpContext.Session.SetString("userName", user.ToList()[0].userName.ToString());
                    HttpContext.Session.SetString("userEmail", obj.userEmail.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("index", "login");
                }
            }
            else
            {
                return RedirectToAction("index", "login");
            }
           // }
            /*    Console.WriteLine(obj);

              //  if(obj.userPassword!= (user.ToList())[0].userPassword ) {
                //    Console.WriteLine(ModelState);
              //     

                  //  return View("Index","Home");
                //}
                if (ModelState.IsValid)
                {
                 //   TempData["success"] = "User log in successfully";
                    Console.WriteLine("loogin");

                }*/
        }
    }
}
