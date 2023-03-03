using Microsoft.AspNetCore.Mvc;

namespace SocialMediaWeb.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
