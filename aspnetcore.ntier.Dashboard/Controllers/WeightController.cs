using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class WeightController : BaseController
    {
        private readonly IWeightService _weightService;

        public WeightController(IWeightService weightService)
        {
            _weightService = weightService;
        }

        public async Task<IActionResult> Edit(int siteId, decimal? WId)
        {
            EditWeightViewModel weight = new EditWeightViewModel();
            if (WId.HasValue)
            {
                var result = await _weightService.GetBySiteIdAsync(siteId, WId.Value, User.Identity.Name);
                if (result is not null)
                {
                    weight = new EditWeightViewModel
                    {
                        Bill_Name = result.Bill_Name,
                        Bill_Num = result.Bill_Num,
                        Vio_Num = result.Vio_Num,
                        WId = result.WId
                    };
                }

            }
            weight.SiteId = siteId;
            return View(weight);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditWeightViewModel mdoel)
        {
            if (ModelState.IsValid)
            {
                var editModel = new EditWeightTblDto
                {
                    Bill_Name = mdoel.Bill_Name,
                    Bill_Num = mdoel.Bill_Num,
                    Vio_Num = mdoel.Vio_Num,
                    WID = mdoel.WId.Value
                };
                await _weightService.UpdateAsync(editModel);
                TempData["MessageStatus"] = "تم الحفظ بنجاح";
            }
            return RedirectToAction(nameof(Edit), new { siteId = mdoel.SiteId, WId = mdoel.WId });
        }
    }
}
