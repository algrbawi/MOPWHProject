using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis
{

    public class UserController : BaseApiController
    {
        private readonly IUserTblService _userTblService;

        public UserController(IUserTblService userTblService)
        {
            _userTblService = userTblService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UsersTblDto model)
        {
            await _userTblService.AddAsync(model);
            return Ok();
        }
    }
}
