using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Filters
{
    public class ApiValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erros = new List<object>();

                foreach (var state in context.ModelState)
                {
                    erros.Add(new { Key = state.Key, Errors = state.Value.Errors.Select(x => x.ErrorMessage) });
                }
                context.Result = new BadRequestObjectResult(erros);
            }

            base.OnActionExecuting(context);
        }
    }
}
