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
        public IActionResult PostPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post obj)
        {

            _db.Posts.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}
