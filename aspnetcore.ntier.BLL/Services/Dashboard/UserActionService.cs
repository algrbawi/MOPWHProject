using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using aspnetcore.ntier.DTO.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

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
        public IPagedList<UserActionDto> GetPagedList(int pageNumber = 1, int pageSize = 100)
        {
            var results = _userActionRepository.GetListPaginationAsync(null, null, default, pageNumber, pageSize);
            var resultDto = _mapper.Map<List<UserActionDto>>(results);
            return new StaticPagedList<UserActionDto>(resultDto, results.GetMetaData());
        }
    }
}
