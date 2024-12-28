using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis
{

    public class NationController : BaseApiController
    {

        private readonly INationService _nationService;

        public NationController(INationService nationService)
        {
            _nationService = nationService;
        }

        [HttpPost("AddNation")]
        public async Task<IActionResult> AddNation(NationTblDto model)
        {
            await _nationService.AddAsync(model);
            return Ok();
        }
    }
}
