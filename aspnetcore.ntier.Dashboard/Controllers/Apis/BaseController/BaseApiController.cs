using aspnetcore.ntier.Dashboard.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController
{

    [ApiController]
    [ApiValidateModel]
    [ApiVersion("1")]
    [ServiceFilter(typeof(ExceptionFilter))]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseApiController : ControllerBase
    {
    }
}
