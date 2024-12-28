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
    public class NationService : INationService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<NationTbl> _nationTblRepository;

        public NationService(IMapper mapper, IGenericRepository<NationTbl> nationTblRepository)
        {
            _mapper = mapper;
            _nationTblRepository = nationTblRepository;
        }

        public async Task AddAsync(NationTblDto model)
        {
            var weightTbl = _mapper.Map<NationTbl>(model);
            await _nationTblRepository.AddAsync(weightTbl);
        }
    }
}
