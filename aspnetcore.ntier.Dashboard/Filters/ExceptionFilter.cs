using aspnetcore.ntier.BLL.Services.Dashboard;
using aspnetcore.ntier.BLL.Services.IServices;
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
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if (context.Exception.GetType() == typeof(BadRequestException) || context.Exception.GetType() == typeof(UserNotFoundException))
            {
                context.Result = new BadRequestObjectResult(new { Error = context.Exception?.InnerException?.Message is null ? context.Exception?.Message : context.Exception?.InnerException?.Message });
            }
            else
            {

                var request = context.HttpContext.Request;
                var service = (DashboardUserService)context.HttpContext.RequestServices.GetService(typeof(IDashboardUserService));
                var query = request.QueryString;
                var path = request.Path;
                var method = request.Method;
                var schema = request.Scheme;
                var body = context.HttpContext.Items["RequestBody"];
                context.Result = new BadRequestObjectResult(new { Error = "Something went wrong please try again later !" });
            }
        }
    }
}
