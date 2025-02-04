using aspnetcore.ntier.BLL.Services.Apis;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Services.PDF;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using aspnetcore.ntier.DTO.DTOs;
using aspnetcore.ntier.DTO.Enum;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using System.Security.Cryptography;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class WeightController : BaseController
    {
        private readonly IWeightService _weightService;
        private readonly ISiteService _siteService;

        public WeightController(IWeightService weightService, ISiteService siteService)
        {
            _weightService = weightService;
            _siteService = siteService;
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

        public async Task<IActionResult> DownloadReport(int siteId, decimal WId)
        {

            try
            {

                var weightReport = await _weightService.GetWeightReportData(siteId, WId, User.Identity.Name);

                if (weightReport.ReportData?.Count() > 0)
                {
                    var site = await _siteService.GetUserSiteAsync(User.Identity.Name, siteId);
                    var pdfDto = new PdfDto
                    {
                        ReportData = weightReport.ReportData,
                        TotalTrucks = weightReport.TotalTrucks,
                        TotalViolationTrucks = weightReport.TotalViolationTrucks,
                        TotalViolationWeight = weightReport.TotalViolationWeight,
                        TotlaViolationNumberMoreThan5 = weightReport.TotlaViolationNumberMoreThan5,
                        TotlaViolationPrice = weightReport.TotlaViolationPrice,
                        reportType = DTO.Enum.ReportType.bill,
                        SiteName = site.SiteName,
                        SiteTitle = site.SiteTitle
                    };
                    PDFService pDFService = new PDFService(pdfDto);

                    var reportPdf = pDFService.GeneratePdf();
                    return File(reportPdf, "application/octet-stream", ReportType.bill + ".pdf");
                }

            }
            catch (Exception)
            {

            }
            return RedirectToAction("index", "home");

        }
    }
}
