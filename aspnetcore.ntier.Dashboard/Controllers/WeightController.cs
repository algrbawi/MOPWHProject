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
                        ClassWeight = result.ClassWeight,
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
                    ClassWeight = mdoel.ClassWeight,
                    WID = mdoel.WId.Value
                };
                await _weightService.UpdateAsync(editModel);
            }
            return RedirectToAction(nameof(Edit), new { siteId = mdoel.SiteId, WId = mdoel.WId });
        }
    }
}
