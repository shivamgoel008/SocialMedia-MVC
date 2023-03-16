using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaWeb.Data;
using SocialMediaWeb.Models;
using System.Collections.Generic;

namespace SocialMediaWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PostController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;// now we can use this _db to retrive all the categories 
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("userId");
            if (userId == null || userId == "")
            {   
                return RedirectToAction("Index", "Login");
            }

            ViewBag.posts = _db.Posts.OrderByDescending(s=>s.postCreationDate);
            return View();
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("postDescription,postCreationDate,imageFile")] Post obj)
        {
            var userId = HttpContext.Session.GetString("userId");
            if (userId == null || userId == "")
            {
                return RedirectToAction("Index", "Login");
            }

            obj.userId = int.Parse(userId);
            if (obj.imageFile?.FileName != null)
            {
                string wwwpat = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(obj.imageFile.FileName);
            string extension = Path.GetExtension(obj.imageFile.FileName);
            obj.postImage=fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path= Path.Combine(wwwpat + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await obj.imageFile.CopyToAsync(fileStream);
                }

            }

            _db.Posts.Add(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
        }
    }
}
