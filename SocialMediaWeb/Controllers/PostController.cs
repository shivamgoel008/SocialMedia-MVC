using Microsoft.AspNetCore.Mvc;

namespace SocialMediaWeb.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
