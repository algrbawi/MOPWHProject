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
    public class UserTblService : IUserTblService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<UsersTbl> _userTblRepository;

        public UserTblService(IMapper mapper, IGenericRepository<UsersTbl> productTblRepository)
        {
            _mapper = mapper;
            _userTblRepository = productTblRepository;
        }
        public async Task AddAsync(UsersTblDto model)
        {
            var userTbl = _mapper.Map<UsersTbl>(model);
            await _userTblRepository.AddAsync(userTbl);
        }
    }
}
