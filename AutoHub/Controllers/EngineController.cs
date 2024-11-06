using AutoHub.Data;
using AutoHub.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Controllers
{
    public class EngineController : Controller
    {
        private readonly AutoHubDbContext dbContext;

        public EngineController(AutoHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var engines = dbContext.Engines.ToList();
            return View(engines);
        }

        [HttpGet]
        public IActionResult Details(string id) 
        {
            bool isValid = Guid.TryParse(id, out Guid guidId);

            if (!isValid) 
            {
                return RedirectToAction(nameof(Index));
            }
            Engine? engines = this.dbContext.Engines
                .Include(e => e.Brand)
                .Include(e => e.Model)
                .FirstOrDefault(e => e.Id == guidId);

            if (engines == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            return this.View(engines);
        }
    }
}
