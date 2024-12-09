using AutoHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoHub.Controllers
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

        public IActionResult Error(int? statusCode = null)
        {
            if (!statusCode.HasValue)
            {
                return View();
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }
            
            return View("Error500");
        }
    }
}
