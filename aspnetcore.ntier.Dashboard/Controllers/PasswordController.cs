using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Filters;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class PasswordController : Controller
    {
        private readonly IDashboardUserService _dashboardUserService;

        public PasswordController(IDashboardUserService dashboardUserService)
        {
            _dashboardUserService = dashboardUserService;
        }

        public IActionResult SetNewPassword()
        {
            return View(new SetNewPasswordRequestViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetNewPassword(SetNewPasswordRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _dashboardUserService.UpdatePassword(User.Identity.Name, model.Password);
                return RedirectToAction("logout", "account");
            }
            return View(model);
        }
    }
}
