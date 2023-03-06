using Microsoft.AspNetCore.Mvc;
using SocialMediaWeb.Data;
using SocialMediaWeb.Models;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace SocialMediaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;// now we can use this _db to retrive all the categories 
        }

        public IActionResult Index()
        {
            IEnumerable < Post > objCatetoryList = _db.Posts.ToList();
            return View(objCatetoryList);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}