using aspnetcore.ntier.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace aspnetcore.ntier.BLL.Services.IServices
{
    public interface IUserActionService
    {
        Task AddAsync(string message);
        IPagedList<UserActionDto> GetPagedList(int pageNumber = 1, int pageSize = 100);
    }
}
