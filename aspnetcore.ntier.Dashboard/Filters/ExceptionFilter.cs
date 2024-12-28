using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aspnetcore.ntier.Dashboard.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(new { Error = context.Exception?.InnerException?.Message is null ? context.Exception?.Message : context.Exception?.InnerException?.Message });
        }
    }
}
