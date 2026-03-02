using aspnetcore.ntier.BLL.Exceptions;
using aspnetcore.ntier.BLL.Services.Dashboard;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Utilities.ModelStateValidation;
using aspnetcore.ntier.Dashboard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;
using System.Security.Claims;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ModelStateValidation _modelStateValidation;
        private readonly IUserActionService _userActionService;

        public AccountController(IAccountService accountService, ModelStateValidation modelStateValidation, IUserActionService userActionService)
        {
            _accountService = accountService;
            _modelStateValidation = modelStateValidation;
            _userActionService = userActionService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [EnableRateLimiting("RateLimit")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(model.Email, model.Password, model.RemmberMe);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await _userActionService.AddAsync($"{model.Email} عملية تسجيل دخول ناجحة");
                    return Redirect(model.ReturnUrl);
                }
                await _userActionService.AddAsync($"{model.Email} محاولة تسجيل دخول غير ناجحة");
                _modelStateValidation.ModelStateErrors(ModelState, new Dictionary<string, string> { { "", result.ErrorMessage } });

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
