using Microsoft.AspNetCore.Mvc;

namespace SocialMediaWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
