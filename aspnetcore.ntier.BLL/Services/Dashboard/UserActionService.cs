using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.Dashboard
{
    public class UserActionService : IUserActionService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<UserAction> _userActionRepository;

        public UserActionService(IMapper mapper, IGenericRepository<UserAction> userActionRepository)
        {
            _mapper = mapper;
            _userActionRepository = userActionRepository;
        }

        public async Task AddAsync(string message)
        {
            var userAction = new UserAction
            {
                ActionTime = DateTime.UtcNow,
                Message = message
            };
            await _userActionRepository.AddAsync(userAction);
        }
        //public async Task AddAsync(string message)
        //{
        //    var userAction = new UserAction
        //    {
        //        ActionTime = DateTime.UtcNow,
        //        Message = message
        //    };
        //    await _userActionRepository.GetListAsync().;
        //}
    }
}
