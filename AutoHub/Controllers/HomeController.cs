using AutoHub.Models;
using AutoHub.Web.ViewModels.Models;
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

        [HttpGet]
        public IActionResult Error403()
        {
            return View();
        }

        [HttpGet("/Home/Error/{statusCode?}")]
        public IActionResult Error(int? statusCode = null)
        {
          
            if (statusCode == 500)
            {
                return this.View("Error500");
            }
            else if (statusCode == 404)
            {
                return this.View("Error404");
            }
            else if (statusCode == 403)
            {
                return this.View("Error403");
            }

            return View("Error500");
        }
    }
}
