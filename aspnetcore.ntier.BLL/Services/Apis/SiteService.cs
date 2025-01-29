using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using aspnetcore.ntier.DTO.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.Apis
{
    public class SiteService : ISiteService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<SiteTbl> _siteTblRepository;
        private readonly IGenericRepository<DashboardUser> _dashboardUserRepository;

        public SiteService(IMapper mapper, IGenericRepository<SiteTbl> siteTblRepository, IGenericRepository<DashboardUser> dashboardUserRepository)
        {
            _mapper = mapper;
            _siteTblRepository = siteTblRepository;
            _dashboardUserRepository = dashboardUserRepository;
        }
        public async Task AddAsync(SiteTblDto model)
        {
            var siteTbl = _mapper.Map<SiteTbl>(model);
            await _siteTblRepository.AddAsync(siteTbl);
        }
        public async Task<SiteTblDto> GetAsync(decimal Id)
        {
            var results = await _siteTblRepository.GetAsync(s => s.SiteId == Id);
            return _mapper.Map<SiteTblDto>(results);
        }
        public async Task<List<SiteTblDto>> GetListAsync()
        {
            var results = await _siteTblRepository.GetListAsync();
            return _mapper.Map<List<SiteTblDto>>(results);
        }
        public async Task<List<SiteTblDto>> GetUserSitesListAsync(string email, string siteName = "")
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email == email);
            var results = await _siteTblRepository.GetListAsync(x => (user.IsSuperAdmin || x.AccessUsers.Any(x => x.DashboardUserId == user.Id)) && (string.IsNullOrEmpty(siteName) ? true : x.SiteName.ToLower() == siteName.ToLower()), inc => inc.Include(ua => ua.AccessUsers));
            return _mapper.Map<List<SiteTblDto>>(results);
        }
        public async Task<SiteTblDto> GetUserSiteAsync(string email, int siteId)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email == email);
            var results = await _siteTblRepository.GetAsync(x => (user.IsSuperAdmin || x.AccessUsers.Any(x => x.SiteTblId == siteId && x.DashboardUserId == user.Id)), inc => inc.Include(ua => ua.AccessUsers));
            return _mapper.Map<SiteTblDto>(results);
        }
        public async Task<List<SiteTblDto>> GetListAsync(List<decimal>? Ids = null)
        {
            var results = await _siteTblRepository.GetListAsync(s => (Ids == null ? true : Ids.Contains(s.SiteId)));
            return _mapper.Map<List<SiteTblDto>>(results);
        }

        public async Task<bool> IsUserAutorized(string emailAddress, int siteId)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email == emailAddress, inc => inc.Include(ac => ac.AccessUsers));
            if (user == null)
            {
                return false;
            }
            if (user.IsSuperAdmin || user.AccessUsers?.Select(x => x.SiteTblId).Contains(siteId) is not null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IsUserAutorized(string emailAddress, string siteName)
        {
            var user = await _dashboardUserRepository.GetAsync(x => x.Email == emailAddress, inc => inc.Include(ac => ac.AccessUsers));
            var site = await _siteTblRepository.GetAsync(x => x.SiteName.ToLower() == siteName.ToLower());
            if (user == null)
            {
                return false;
            }
            if (user.IsSuperAdmin || user.AccessUsers?.Select(x => x.SiteTblId).Contains(site.SiteId) is not null)
            {
                return true;
            }
            return false;
        }
        public async Task<List<SiteTblDto>> GetListAsync(string name)
        {
            var results = await _siteTblRepository.GetListAsync(s => s.SiteName == name);
            return _mapper.Map<List<SiteTblDto>>(results);
        }
    }
}
