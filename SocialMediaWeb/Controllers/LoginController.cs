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
            var userId = HttpContext.Session.GetString("userId");
            if (userId != null )
            {
                return RedirectToAction("Index", "Post");
            }
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
                    TempData["success"] = "User logged in successfully";
                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    TempData["error"] = "Incorrect Password";
                    return RedirectToAction("index", "Login");
                }
            }
            else
            {
                TempData["error"]="User not found";
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
