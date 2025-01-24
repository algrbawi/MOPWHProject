using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using aspnetcore.ntier.DTO.DTOs;
using AutoMapper;
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

        public SiteService(IMapper mapper, IGenericRepository<SiteTbl> siteTblRepository)
        {
            _mapper = mapper;
            _siteTblRepository = siteTblRepository;
        }
        public async Task AddAsync(SiteTblDto model)
        {
            var siteTbl = _mapper.Map<SiteTbl>(model);
            await _siteTblRepository.AddAsync(siteTbl);
        }
        public async Task<List<SiteTblDto>> GetListAsync()
        {
            var results = await _siteTblRepository.GetListAsync();
            return _mapper.Map<List<SiteTblDto>>(results);
        }
        public async Task<List<SiteTblDto>> GetListAsync(List<decimal>? Ids = null)
        {
            var results = await _siteTblRepository.GetListAsync(s => (Ids == null ? true : Ids.Contains(s.SiteId)));
            return _mapper.Map<List<SiteTblDto>>(results);
        }

        public async Task<List<SiteTblDto>> GetListAsync(string name)
        {
            var results = await _siteTblRepository.GetListAsync(s => s.SiteName == name);
            return _mapper.Map<List<SiteTblDto>>(results);
        }
    }
}
