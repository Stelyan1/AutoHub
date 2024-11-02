using AutoHub.Data;
using AutoHub.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Controllers
{
    public class ModelController : Controller
    {
        private readonly AutoHubDbContext dbContext;

        public ModelController(AutoHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Model> allModels = this.dbContext
                .Models
                .ToList();

            return View(allModels);
        }
    }
}
