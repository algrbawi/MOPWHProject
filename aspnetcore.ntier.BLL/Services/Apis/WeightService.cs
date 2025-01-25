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
    public class WeightService : IWeightService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<WeightTbl> _weightTblRepository;

        public WeightService(IMapper mapper, IGenericRepository<WeightTbl> weightTblRepository)
        {
            _mapper = mapper;
            _weightTblRepository = weightTblRepository;
        }

        public async Task AddAsync(WeightTblDto model)
        {
            var weightTbl = _mapper.Map<WeightTbl>(model);
            await _weightTblRepository.AddAsync(weightTbl);
        }

        public async Task<List<WeightTblDto>> GetWeightBySiteIdAsync(int SiteId, DateOnly From, DateOnly To)
        {

            var results = await _weightTblRepository.GetListAsync(
                x => x.SiteId == SiteId && x.InDate >= From && x.InDate <= To);

            return _mapper.Map<List<WeightTblDto>>(results);
        }
    }
}
