using aspnetcore.ntier.Dashboard.Attributes;
using aspnetcore.ntier.Dashboard.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Base
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [CheckUserCredentials]
    [TrackUser]
    [DashboardExceptionFilter]
    public class BaseController : Controller
    {

    }
}
