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
    public class UserController : ControllerBase
    {
        private readonly IUserTblService _userTblService;

        public UserController(IUserTblService userTblService)
        {
            _userTblService = userTblService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(UsersTblDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userTblService.AddAsync(model);
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
