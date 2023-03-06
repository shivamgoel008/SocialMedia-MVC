using Microsoft.AspNetCore.Mvc;
using SocialMediaWeb.Data;
using SocialMediaWeb.Models;
namespace SocialMediaWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PostController(ApplicationDbContext db,IWebHostEnvironment hostEnvironment)
        {
            _db = db;// now we can use this _db to retrive all the categories 
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("postDescription,postCreationDate,imageFile")] Post imageModel)
        {

            
                // save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.imageFile.FileName);
                string extension = Path.GetExtension(imageModel.imageFile.FileName);
                imageModel.postImage=fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                string path=Path.Combine(wwwRootPath+"/Image/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.imageFile.CopyToAsync(fileStream);
                }

                // insert record
                _db.Add(imageModel);
                await _db.SaveChangesAsync();
                return RedirectToAction();
            

        }
    }
}
