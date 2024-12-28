using aspnetcore.ntier.BLL.Services.Apis;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis
{

    public class TruckController : BaseApiController
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpPost("AddTruck")]
        public async Task<IActionResult> AddTruck(TrucksTblDto model)
        {
            await _truckService.AddAsync(model);
            return Ok();
        }
    }
}
