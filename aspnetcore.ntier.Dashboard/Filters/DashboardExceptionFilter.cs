using aspnetcore.ntier.BLL.Exceptions;
using aspnetcore.ntier.BLL.Services.Dashboard;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Services.Log;
using aspnetcore.ntier.BLL.Utilities.CustomExceptions;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aspnetcore.ntier.Dashboard.Filters
{
    public class DashboardExceptionFilter : Attribute, IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var routeData = new RouteValueDictionary(new
            {
                controller = "Error",
                action = "Index",
            });

            context.Result = new RedirectToRouteResult(routeData);
        }
    }
}
