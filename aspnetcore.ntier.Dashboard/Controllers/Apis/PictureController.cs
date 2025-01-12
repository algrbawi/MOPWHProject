using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Apis.BaseController;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers.Apis
{
    public class PictureController : BaseApiController
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        [HttpPost("AddPicture")]
        public async Task<IActionResult> AddPicture(PictureTblDto model)
        {
            await _pictureService.AddAsync(model);
            return Ok();
        }
    }
}
