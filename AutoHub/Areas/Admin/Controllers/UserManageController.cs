using AutoHub.Areas.Admin.ViewModels;
using AutoHub.Data.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class UserManageController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

        public UserManageController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var users = _userManager.Users.ToList();
			var userViewModels = new List<UserManageViewModel>();

			foreach (var user in users) 
			{
				var roles = await _userManager.GetRolesAsync(user);
				userViewModels.Add(new UserManageViewModel
				{
					UserId = user.Id,
					Email = user.Email ?? string.Empty,
					UserName = user.UserName ?? string.Empty,
					UserRoles = roles.ToList()
				});
			}
			return View("~/Areas/Admin/Views/UserManagement/Index.cshtml", userViewModels);

        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleId);

				if (roleExist)
				{
					if (!await _userManager.IsInRoleAsync(user, roleId))
					{
						var result = await _userManager.AddToRoleAsync(user, roleId);
					}
				}
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
		public async Task<IActionResult> RemoveRole(string userId, string roleName)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user != null && await _roleManager.RoleExistsAsync(roleName))
			{
				await _userManager.RemoveFromRoleAsync(user, roleName);
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteUser(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user != null)
			{
				await _userManager.DeleteAsync(user);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
