using aspnetcore.ntier.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.IServices
{
    public interface ISiteService
    {
        Task AddAsync(SiteTblDto model);
        Task<SiteTblDto> GetAsync(decimal Id);
        Task<List<SiteTblDto>> GetListAsync();
        Task<List<SiteTblDto>> GetListAsync(List<decimal>? Ids = null);
        Task<List<SiteTblDto>> GetListAsync(string name);
        Task<List<SiteTblDto>> GetUserSitesListAsync(string email, string siteName = "");
        Task<SiteTblDto> GetUserSiteAsync(string email, int siteId);
        Task<bool> IsUserAutorized(string emailAddress, int siteId);
        Task<bool> IsUserAutorized(string emailAddress, string siteName);
    }
}
