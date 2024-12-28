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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductsTblDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.AddAsync(model);
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
