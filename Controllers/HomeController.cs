using CookiesProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CookiesProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateCookie()
        {
            string key = "Ornek_Cookie";
            string value = "Merhaba dünyaaaa";
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(5)
            };
            Response.Cookies.Append(key, value, options);
            return View("Index");
     
        }

        public IActionResult ReadCookie()
        {
            string key = "Ornek_Cookie";
            var CookieValue = Request.Cookies[key];

            return View("Index");
        }

        public IActionResult RemoveCookie()
        {
            string key = "Ornek_Cookie";
            string value = string.Empty;
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Append(key, value, options);

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}