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

        [HttpGet]
        public IActionResult Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);
            if (!isValid) 
            {
                return this.RedirectToAction(nameof(Index));
            }

            Model? model = this.dbContext
                .Models.FirstOrDefault(m => m.Id == guidId);

            if (model == null) 
            {
                return RedirectToAction(nameof(Index));
            }
                
                
            return this.View(model);
        }
    }
}
