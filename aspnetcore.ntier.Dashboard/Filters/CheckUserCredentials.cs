using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace aspnetcore.ntier.Dashboard.Filters
{
    public class CheckUserCredentials : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userPrinciples = context.HttpContext.User;
            var userService = context.HttpContext.RequestServices.GetService<IDashboardUserService>();
            var userEmail = context.HttpContext.User.Identity.Name;
            var user = userService.GetByEmailAsync(userEmail).Result;
            var controller = (BaseController)context.Controller;

            if (user is null || user.IsSuperAdmin != isTheUserSuperAdmin(userPrinciples))
            {
                context.Result = controller.RedirectToAction("logout", "account");
            }
            if (user.AccessUsers.Select(x => x.SiteTblId).Count() != GetUserAccessToSites(userPrinciples).Count() || !user.AccessUsers.Select(x => x.SiteTblId).All(GetUserAccessToSites(userPrinciples).Contains))
            {
                context.Result = controller.RedirectToAction("logout", "account");
            }
            if (user.IsAllowedToEdit != isTheUserAllowedToEdit(userPrinciples))
            {
                context.Result = controller.RedirectToAction("logout", "account");
            }

        }
        private bool isTheUserSuperAdmin(ClaimsPrincipal User)
        {
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role && x.Value == "SuperAdmin");
            return role is not null ? true : false;
        }
        private bool isTheUserAllowedToEdit(ClaimsPrincipal User)
        {
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role && x.Value == "AllowToEdit");
            return role is not null ? true : false;
        }
        private List<decimal> GetUserAccessToSites(ClaimsPrincipal User)
        {
            var role = User.Claims.Where(x => x.Type == ClaimTypes.Role && decimal.TryParse(x.Value, out _) == true).Select(x => Convert.ToDecimal(x.Value)).ToList();
            return role;
        }
    }
}
