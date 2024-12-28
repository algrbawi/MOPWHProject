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
    public class TruckService: ITruckService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TrucksTbl> _truckTblRepository;

        public TruckService(IMapper mapper, IGenericRepository<TrucksTbl> truckTblRepository)
        {
            _mapper = mapper;
            _truckTblRepository = truckTblRepository;
        }
        public async Task AddAsync(TrucksTblDto model)
        {
            var truck = _mapper.Map<TrucksTbl>(model);
            await _truckTblRepository.AddAsync(truck);
        }

    }
}
