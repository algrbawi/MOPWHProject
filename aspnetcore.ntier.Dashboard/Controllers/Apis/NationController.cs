using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NationController : ControllerBase
    {

        private readonly INationService _nationService;

        public NationController(INationService nationService)
        {
            _nationService = nationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(NationTblDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _nationService.AddAsync(model);
                    return Ok();
                }
                return BadRequest(ModelState.Keys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);

            }
        }
    }
}
