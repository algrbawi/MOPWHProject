using aspnetcore.ntier.BLL.Services.Apis;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
using aspnetcore.ntier.Dashboard.Filters;
using aspnetcore.ntier.Dashboard.Models.Api;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> AddWeight(WeightRequestViewModel model)
        {
            await _weightService.AddAsync(new WeightTblDto
            {
                SiteId = model.SiteId,
                ClassWeight = model.ClassWeight,
                DiffWeight = model.DiffWeight,
                DriverId = model.DriverId,
                InDate = model.InDate,
                InTime = model.InTime,
                NationId = model.NationId,
                ProductId = model.ProductId,
                SeqNo = model.SeqNo,
                Transed = model.Transed,
                TruckNum = model.TruckNum,
                UserId = model.UserId,
                VioPrice = model.VioPrice,
                WeightLocation = model.WeightLocation,
                WeightNote = model.WeightNote,
                WId = model.WId,
                WeightState = model.WeightState,
                WeightS = model.WeightS,
                VioWeight = model.VioWeight,
                TruckWeight = model.TruckWeight,
                WClassId = model.WClassId
            });
            return Ok();
        }

        [HttpPost("AddWeightClass")]
        public async Task<IActionResult> AddWeightClass(WeightClassTblDto model)
        {
            await _weightClassTblService.AddAsync(model);
            return Ok();
        }

        [HttpGet("GetTruckVioApi")]
        public async Task<IActionResult> GetTruckVioApi()
        {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized();
            }

            var result = await _weightService.GetTruckVioAsync(userEmail);
            return Ok(result);
        }
    }
}
