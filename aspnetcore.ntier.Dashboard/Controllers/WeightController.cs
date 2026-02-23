using aspnetcore.ntier.BLL.Services.Apis;
using aspnetcore.ntier.BLL.Services.Dashboard;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Services.PDF;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using aspnetcore.ntier.DTO.DTOs;
using aspnetcore.ntier.DTO.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using System.Security.Cryptography;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    [Authorize(Roles = "AllowToEdit, SuperAdmin")]
    public class WeightController : BaseController
    {
        private readonly IWeightService _weightService;
        private readonly ISiteService _siteService;
        private readonly IUserActionService _userActionService;

        public WeightController(IWeightService weightService, ISiteService siteService, IUserActionService userActionService)
        {
            _weightService = weightService;
            _siteService = siteService;
            _userActionService = userActionService;
        }

        public async Task<IActionResult> Edit(int siteId, decimal? WId)
        {
            EditWeightViewModel weight = new EditWeightViewModel();

            if (ModelState.IsValid)
            {

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
            return View(weight);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditWeightViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editModel = new EditWeightTblDto
                {
                    Bill_Name = model.Bill_Name,
                    Bill_Num = model.Bill_Num,
                    Vio_Num = model.Vio_Num,
                    WID = model.WId.Value
                };
                await _weightService.UpdateAsync(editModel);
                await _userActionService.AddAsync($"{User.Identity.Name} لقد قام المستخدم " +
                                                                    $"{Environment.NewLine}" +
                                                                    $"بتعديل على الفاتورة" +
                                                                    $"{Environment.NewLine}" +
                                                                    $"رقم الوصل:  {model.WId}"
                                                  );
                TempData["MessageStatus"] = "تم الحفظ بنجاح";
            }
            return RedirectToAction(nameof(Edit), new { siteId = model.SiteId, WId = model.WId });
        }
    }
}
