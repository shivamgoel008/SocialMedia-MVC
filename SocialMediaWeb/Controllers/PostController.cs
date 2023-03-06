using Microsoft.AspNetCore.Mvc;
using SocialMediaWeb.Data;
using SocialMediaWeb.Models;
namespace SocialMediaWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext db)
        {
            _db = db;// now we can use this _db to retrive all the categories 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Post obj)
        {
            Console.WriteLine(HttpContext.Session.GetString("userId"));
            Console.WriteLine(HttpContext.Session.GetString("userName"));
            if (ModelState.IsValid)
            {
                

                Console.WriteLine(obj);
                _db.Posts.Add(obj);
                return RedirectToAction("index","home");
            }
            return RedirectToAction("índex");
        }
    }
}
