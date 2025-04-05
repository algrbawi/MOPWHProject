using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardUserController : BaseController
    {
        private readonly IDashboardUserService _dashboardUserService;
        private readonly ISiteService _siteService;

        public DashboardUserController(IDashboardUserService dashboardUserService, ISiteService siteService)
        {
            _dashboardUserService = dashboardUserService;
            _siteService = siteService;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _dashboardUserService.GetAllAsync();
            return View(results);
        }

        public async Task<IActionResult> Add()
        {
            var model = new AddEditViewModel();
            model.SiteItems = await GetSitesListItems();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddEditViewModel model)
        {
            var siteIterms = await GetSitesListItems(model.SitePermissions);
            if (ModelState.IsValid)
            {
                try
                {
                    model.SiteItems = siteIterms;
                    var dto = new DashboardUserDto
                    {
                        IsActive = model.IsActive,
                        IsAllowedToEdit = model.IsAllowedToEdit,
                        Email = model.Email,
                        IsSuperAdmin = model.IsSuperAdmin,
                        Id = model.Id,
                        Name = model.Name,
                        AccessUsers = model.SitePermissions?.Select(si => new AccessUserDto
                        {
                            DashboardUserId = model.Id,
                            SiteTblId = si
                        }).ToList()
                    };
                    if (!model.IsSuperAdmin && model.SitePermissions is null || model.SitePermissions?.Count() == 0)
                    {
                        ModelState.AddModelError("SitePermissions", "يرجى إضافة صلاحيات المستخدم");
                        return View(model);
                    }
                    await _dashboardUserService.AddUserAsync(dto, model.Password);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                    return View(model);
                }

            }
            ViewBag.MessageStatus = "تم الأضافة بنجاح";

            return View(new AddEditViewModel() { SiteItems = siteIterms });
        }


        public async Task<IActionResult> Edit(int Id)
        {
            var result = await _dashboardUserService.GetByIdAsync(Id);

            var model = new AddEditViewModel()
            {
                IsActive = result.IsActive,
                Email = result.Email,
                Id = result.Id,
                IsSuperAdmin = result.IsSuperAdmin,
                Name = result.Name,
                Password = "11111111aA!",
                IsAllowedToEdit = result.IsAllowedToEdit,
                SiteItems = await GetSitesListItems(result.AccessUsers.Select(x => x.SiteTblId).ToList())
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.SiteItems = await GetSitesListItems(model.SitePermissions);
                    var dto = new DashboardUserDto
                    {
                        IsActive = model.IsActive,
                        IsAllowedToEdit = model.IsAllowedToEdit,
                        Email = model.Email,
                        IsSuperAdmin = model.IsSuperAdmin,
                        Id = model.Id,
                        Name = model.Name,
                        AccessUsers = model.SitePermissions?.Select(si => new AccessUserDto
                        {
                            DashboardUserId = model.Id,
                            SiteTblId = si
                        }).ToList()
                    };
                    if (!model.IsSuperAdmin && model.SitePermissions is null || model.SitePermissions?.Count() == 0)
                    {
                        ModelState.AddModelError("SitePermissions", "يرجى إضافة صلاحيات المستخدم");
                        return View(model);

                    }
                    await _dashboardUserService.EditUserAsync(dto, model.Password);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("Email", ex.Message);
                    return View(model);
                }
                ViewBag.MessageStatus = "تم التعديل بنجاح";
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove([FromForm] int userId)
        {
            if (ModelState.IsValid)
            {
                await _dashboardUserService.RemoveUserAsync(userId);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<SelectListItem>> GetSitesListItems(List<decimal>? userSiteAccess = null)
        {
            var sites = await _siteService.GetListAsync();
            return sites.Select(x => new SelectListItem { Text = x.SiteTitle, Value = x.SiteId.ToString(), Selected = (userSiteAccess is not null) ? userSiteAccess.Contains(x.SiteId) : false }).ToList();
        }
    }
}
