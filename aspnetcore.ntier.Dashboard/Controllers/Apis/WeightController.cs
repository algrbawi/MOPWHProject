using aspnetcore.ntier.BLL.Services.Apis;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
using aspnetcore.ntier.Dashboard.Filters;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis
{

    public class WeightController : BaseApiController
    {
        private readonly IWeightService _weightService;
        private readonly IWeightClassTblService _weightClassTblService;

        public WeightController(IWeightService weightService, IWeightClassTblService weightClassTblService)
        {
            _weightService = weightService;
            _weightClassTblService = weightClassTblService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("AddWeight")]
        public async Task<IActionResult> AddWeight(WeightTblDto model)
        {
            await _weightService.AddAsync(model);
            return Ok();
        }

        [HttpPost("AddWeightClass")]
        public async Task<IActionResult> AddWeightClass(WeightClassTblDto model)
        {
            await _weightClassTblService.AddAsync(model);
            return Ok();
        }
    }
}
