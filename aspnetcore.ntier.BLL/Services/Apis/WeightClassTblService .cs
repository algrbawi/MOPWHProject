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
    public class WeightClassTblService : IWeightClassTblService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<WeightClassTbl> _weightClassTblRepository;
        public WeightClassTblService(IMapper mapper, IGenericRepository<WeightClassTbl> weightClassTblRepository)
        {
            _mapper = mapper;
            _weightClassTblRepository = weightClassTblRepository;
        }
        public async Task AddAsync(WeightClassTblDto model)
        {
            var wightClassTbl = _mapper.Map<WeightClassTbl>(model);
            await _weightClassTblRepository.AddAsync(wightClassTbl);
        }
    }
}
