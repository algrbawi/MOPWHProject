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
    public class LogService : ILogService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<LogTbl> _logTblRepository;

        public LogService(IMapper mapper, IGenericRepository<LogTbl> logTblRepository)
        {
            _mapper = mapper;
            _logTblRepository = logTblRepository;
        }

        public async Task<List<LogTblDto>> GetListAsync(List<decimal> sitesIds)
        {
            var results = await _logTblRepository.GetListAsync(x => sitesIds.Contains(x.SiteId.Value));
            return _mapper.Map<List<LogTblDto>>(results);

        }

        public async Task AddAsync(LogTblDto model)
        {
            var en = _mapper.Map<LogTbl>(model);
            await _logTblRepository.AddAsync(en);

        }

    }
}
