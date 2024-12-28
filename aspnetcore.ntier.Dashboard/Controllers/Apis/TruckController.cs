using aspnetcore.ntier.BLL.Services.Apis;
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
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TrucksTblDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _truckService.AddAsync(model);
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
