using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserActionController : BaseController
    {
        private readonly IUserActionService _userActionService;

        public UserActionController(IUserActionService userActionService)
        {
            _userActionService = userActionService;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            var results = _userActionService.GetPagedList(pageNumber);
            return View(results);
        }
    }
}
