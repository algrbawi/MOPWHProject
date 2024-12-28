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
    public class DriverService : IDriverService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<DriversTbl> _driverTblRepository;

        public DriverService(IMapper mapper, IGenericRepository<DriversTbl> driverTblRepository)
        {
            _mapper = mapper;
            _driverTblRepository = driverTblRepository;
        }

        public async Task AddAsync(DriversTblDto model)
        {
            var driverTbl = _mapper.Map<DriversTbl>(model);
            await _driverTblRepository.AddAsync(driverTbl);
        }
    }
}
