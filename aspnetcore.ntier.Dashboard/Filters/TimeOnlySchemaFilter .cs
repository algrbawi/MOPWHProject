using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace aspnetcore.ntier.Dashboard.Filters
{
    public class TimeOnlySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(TimeOnly) || context.Type == typeof(DateOnly))
            {
                schema.Type = "string";
            }
        }
    }
}
