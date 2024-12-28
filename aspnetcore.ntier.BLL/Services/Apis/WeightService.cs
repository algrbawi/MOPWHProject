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
        private readonly IGenericRepository<WeightTbl> _WeightClassTblRepository;

        public WeightService(IMapper mapper, IGenericRepository<WeightTbl> weightClassTblRepository)
        {
            _mapper = mapper;
            _WeightClassTblRepository = weightClassTblRepository;
        }

        public async Task AddAsync(WeightTblDto model)
        {
            var weightTbl = _mapper.Map<WeightTbl>(model);
            await _WeightClassTblRepository.AddAsync(weightTbl);
        }
    }
}
