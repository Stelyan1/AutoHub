using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	[Route("Admin")]
	public class HomeController : Controller
	{
		[Route("")]
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
